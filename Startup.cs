using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using winter_intex_2_5.Data;
using winter_intex_2_5.Data.Repositories;
using winter_intex_2_5.Models;
using winter_intex_2_5.Services;

namespace winter_intex_2_5
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // attempt to configure HTTPS forwarding
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.AddCertificateForwarding(options =>
                options.CertificateHeader = "arn:aws:acm:us-east-1:803541727576:certificate/bbc77353-63fd-4471-b0e3-62c9fa50a175");

            if (_env.IsDevelopment())
            {
                services.AddDbContext<MummyContext>(options =>
                    options.UseNpgsql(Configuration.GetSection("RDS:Mummy")["MummyConnect"])
                );

                // enable Google sign in
                services.AddAuthentication()
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");

                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                });
            }
            else
            {
                services.AddDbContext<MummyContext>(options =>
                    options.UseNpgsql(Configuration["MummyDB"])
                );

                // enable Google sign in
                services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration["GoogleClientId"];
                    options.ClientSecret = Configuration["GoogleClientSecret"];
                });
            }


                services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequiredLength = 10;
                });

            services.AddRazorPages();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IMummyRepository, EFMummyRepository>();

            //create onnx sessions
            var sexPath = Path.Combine(_env.ContentRootPath, "wwwroot", "onnx", "predict_sex.onnx");
            var sexSession = new InferenceSession(sexPath);

            var wrappingPath = Path.Combine(_env.ContentRootPath, "wwwroot", "onnx", "wrapping_model2.onnx");
            var wrappingSession = new InferenceSession(wrappingPath);

            services.AddSingleton(new InferenceSessions(sexSession, wrappingSession));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddEntityFrameworkStores<MummyContext>()
                .AddDefaultTokenProviders();

            
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddServerSideBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            //create the admin user
            ApplicationUser newAdmin = new ApplicationUser();
            string password = "";

            if(env.IsDevelopment())
            {
                newAdmin.UserName = Configuration.GetSection("Admin")["Username"];
                newAdmin.FirstName = Configuration.GetSection("Admin")["First"];
                newAdmin.LastName = Configuration.GetSection("Admin")["Last"];
                password = Configuration.GetSection("Admin")["Password"];
                newAdmin.Email = Configuration.GetSection("Admin")["Email"];
            }
            else
            {
                newAdmin.UserName = Configuration["AdminUsername"];
                newAdmin.FirstName = Configuration["AdminFirst"];
                newAdmin.LastName = Configuration["AdminLast"];
                password = Configuration["AdminPassword"];
                newAdmin.Email = Configuration["AdminEmail"];
            }

            UserInitializer.InitializeAsync(serviceProvider).GetAwaiter().GetResult();
            UserInitializer.SeedAdministratorAsync(serviceProvider, newAdmin, password).GetAwaiter().GetResult();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseForwardedHeaders();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseForwardedHeaders();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy(); // GDPR cookie policy

            // XSS Protection Header
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                await next();
            });

            //CSP Header
            //app.Use(async (ctx, next) =>
            //{
            //    ctx.Response.Headers.Add("Content-Security-Policy",
            //    "default-src 'self'");
            //    await next();
            //});

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
            });
        }
    }
}
