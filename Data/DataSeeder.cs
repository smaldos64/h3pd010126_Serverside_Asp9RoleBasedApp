using Microsoft.AspNetCore.Identity;

namespace Asp9RoleBasedApp.Data
{
    public static class DataSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roleNames = { "Admin", "Developer", "User" };

            foreach (var roleName in roleNames)
            {
                bool exists = await roleManager.RoleExistsAsync(roleName);
                if (!exists)
                {
                    var roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!roleResult.Succeeded)
                    {
                        // evt log handling her
                    }
                }
            }

            // Opret en Admin-bruger hvis den ikke findes
            string adminEmail = "admin@local";
            string adminPassword = "Admin123!";  // husk: i virkeligheden brug konfiguration eller miljøvariabler

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    // evt log af errors
                    throw new Exception("Fejl ved oprettelse af standard Admin: " + String.Join(",", result.Errors));
                }
            }
            else
            {
                // Hvis brugeren findes men ikke er i Admin rollen, så tilføj den
                if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
