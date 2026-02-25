using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.SeedData
{
    /// <summary>
    /// Seed class to add missing Project permissions to the Claims table
    /// Run this from Program.cs or call AddMissingProjectPermissions() method
    /// </summary>
    public static class ProjectPermissionSeed
    {
        /// <summary>
        /// Adds missing Project permissions (Edit, Delete) to the Claims table
        /// </summary>
        public static async Task AddMissingProjectPermissions(Koala.Portal.Repository.AppDbContext context)
        {
            try
            {
                // Find or create the Project module
                var projectModule = await context.Module.FirstOrDefaultAsync(m => m.Name == "Project");
                if (projectModule == null)
                {
                    projectModule = new Module
                    {
                        Id = Koala.Portal.Core.Helpers.Tools.CreateGuidStr(),
                        Name = "Project",
                        DisplayName = "Proje Yönetimi",
                        Description = "Proje modülü yetkileri"
                    };
                    context.Module.Add(projectModule);
                    await context.SaveChangesAsync();
                }

                // Add Project.Edit permission if it doesn't exist
                if (!await context.Claims.AnyAsync(c => c.Name == "Project.Edit"))
                {
                    context.Claims.Add(new Claims
                    {
                        Id = Koala.Portal.Core.Helpers.Tools.CreateGuidStr(),
                        ModuleId = projectModule.Id,
                        Name = "Project.Edit",
                        DisplayName = "Proje Düzenle",
                        Description = "Proje düzenleme yetkisi"
                    });
                }

                // Add Project.Delete permission if it doesn't exist
                if (!await context.Claims.AnyAsync(c => c.Name == "Project.Delete"))
                {
                    context.Claims.Add(new Claims
                    {
                        Id = Koala.Portal.Core.Helpers.Tools.CreateGuidStr(),
                        ModuleId = projectModule.Id,
                        Name = "Project.Delete",
                        DisplayName = "Proje Sil",
                        Description = "Proje silme yetkisi"
                    });
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log error but don't throw - this is a seed operation
                Console.WriteLine($"Error adding Project permissions: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds missing Project permissions to existing roles
        /// This updates role claims to include the new permissions
        /// </summary>
        public static async Task AddProjectPermissionsToRoles(
            Microsoft.AspNetCore.Identity.RoleManager<Koala.Portal.Core.Models.AppRole> roleManager,
            IEnumerable<string> roleNames = null)
        {
            try
            {
                var roles = roleNames ?? new[] { "Yönetici", "Yazılım", "Teknik", "Logo Destek" };

                foreach (var roleName in roles)
                {
                    var role = await roleManager.FindByNameAsync(roleName);
                    if (role == null) continue;

                    // Add Project.Edit claim
                    var existingClaims = await roleManager.GetClaimsAsync(role);
                    if (!existingClaims.Any(c => c.Type == "Permission" && c.Value == "Project.Edit"))
                    {
                        await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim("Permission", "Project.Edit"));
                    }

                    // Add Project.Delete claim
                    existingClaims = await roleManager.GetClaimsAsync(role);
                    if (!existingClaims.Any(c => c.Type == "Permission" && c.Value == "Project.Delete"))
                    {
                        await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim("Permission", "Project.Delete"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding Project permissions to roles: {ex.Message}");
            }
        }
    }
}
