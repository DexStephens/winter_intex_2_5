using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using winter_intex_2_5.Models;
using System.Linq;
using System.Text.Json;

namespace winter_intex_2_5.Services
{
    public static class UserInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "researcher", "administrator" };

            foreach (var roleName in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    var role = new IdentityRole(roleName);
                    await roleManager.CreateAsync(role);
                }
            }
        }
        public static async Task SeedAdministratorAsync(IServiceProvider serviceProvider, ApplicationUser newAdmin, string password)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = newAdmin.UserName,
                Email = newAdmin.Email,
                FirstName = newAdmin.FirstName,
                LastName = newAdmin.LastName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, password);
                    await userManager.AddToRoleAsync(defaultUser, "Administrator");
                }

            }
        }
    }
}
