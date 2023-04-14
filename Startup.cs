using Microsoft.AspNetCore.Authentication.OAuth.Claims;
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

            // allow cookies/site-switching
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });

            services.AddScoped<IMummyRepository, EFMummyRepository>();

            //create onnx sessions
            var sexPath = Path.Combine(_env.ContentRootPath, "wwwroot", "onnx", "predict_sex.onnx");
            var sexSession = new InferenceSession(sexPath);

            var wrappingPath = Path.Combine(_env.ContentRootPath, "wwwroot", "onnx", "wrapping_model2.onnx");
            var wrappingSession = new InferenceSession(wrappingPath);

            services.AddSingleton(new InferenceSessions(sexSession, wrappingSession));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddEntityFrameworkStores<MummyContext>()
                .AddDefaultTokenProviders();

            
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
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
                app.UseHsts();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseForwardedHeaders();
                // The default HSTS value is 30 days. You may want to change this for production scenarios.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Strict-Transport-Security", "max-age=63072000; includeSubDomains;");
                await next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy(); 

            // XSS Protection Header
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                await next();
            });

            //CSP Header
            app.Use(async (ctx, next) =>
            {
                ctx.Response.Headers.Add("Content-Security-Policy",
                    "default-src 'none'; font-src fonts.googleapis.com fonts.gstatic.com data:; script-src 'self' 'sha256-GTVKyNXbENAnZeEuA5qu+0EV3Srf0AKOJL1iSdiU2p8=' 'sha256-EuabHSnz98x5cuuQ/sdN1Z8gPxaTn00z5J20cvrWKl4=' 'sha256-EuabHSnz98x5cuuQ/sdN1Z8gPxaTn00z5J20cvrWKl4=' 'sha256-fIkC4b4crvv6N/++kl5qCd/nhTe0/JC7KANDL3YeODw=' 'sha256-EuabHSnz98x5cuuQ/sdN1Z8gPxaTn00z5J20cvrWKl4=' 'sha256-oPe/GrpWUonU6WfPTKLb/TdldpgC0lyYFmtg3G4A4j8=' 'sha256-H4IABS2cOkW43LaKS8PJIKb4LQYW8fDGp5bMnfUrJk4='; connect-src 'self'; img-src 'self' cwadmin.byu.edu; style-src 'self' fonts.googleapis.com 'unsafe-hashes' 'sha256-nypvrmcghKKJsRlQiwYyu6Kcq9oyD9RAJ9jsREwI1Os=' 'sha256-dOd10fS6bMFabtGqkPCU80Dni0fTiI0VN1iw8FRoa1s=' 'sha256-H1wubLdugdnFugXFrrB+2Whff/lK1BfrSHQhIlGVErU=' 'sha256-qPTc8MEN993f2X85iD6rZzad5Ai9wTDgGWQUOuMKi7s=' 'sha256-SH1YTVst2sc5A5WJjzNUDYtnxn/kOw1X3ThZwkd8hck=' 'sha256-IfHP2B1mknVMFgr5LV7QIYbApWrK4JPQ/69mRfiZpgA=' 'sha256-lY3/x25zCDEAXrR2rMuzb7TLKSwbH6DewUXG+rQn1lM=' 'sha256-ZjfSlZb0jCKd/Ah+IYb+6b7J3jGBBq1/nOWaFcCLKq8=' 'sha256-aqNNdDLnnrDOnTNdkJpYlAxKVJtLt9CtFLklmInuUAE=' 'sha256-l32kuTgbhZFV7YL2q1Sv/65m8dy+QzAV1CjPDUML0hE=' 'sha256-l32kuTgbhZFV7YL2q1Sv/65m8dy+QzAV1CjPDUML0hE=' 'sha256-alQkhzRik30p4D42M4x52HUwzK1/HLrcDh9ydLkkoOI='; base-uri 'self';form-action 'self'");
                await next();
            });

            //Permission policy header
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Permissions-Policy", "camera=(), microphone=(), geolocation=()");
                await next();
            });

            //Referrer policy header
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
                await next();
            });

            //X-Frame-Options
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                await next();
            });

            //X-Content-Type-Options header
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next();
            });
            //X-Permitted policy
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
                await next();
            });

            //Feature Policy
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Feature-Policy", "camera 'none'; microphone 'none'");
                await next.Invoke();
            });

            //Expect CT
            app.Use(async (context, next) =>
            {
                // Add the Expect-CT header
                context.Response.Headers.Add("Expect-CT", "enforce, max-age=30");

                // Call the next middleware in the pipeline
                await next();
            });


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
