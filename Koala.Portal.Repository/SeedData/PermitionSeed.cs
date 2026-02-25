using System.Security.Claims;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Permissions;
using Microsoft.AspNetCore.Identity;

namespace Koala.Portal.Repository.SeedData
{
    public class PermitionSeed
    {
        public static async Task Seed(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            var yoneticiRole = await roleManager.RoleExistsAsync("Yönetici");
            if (!yoneticiRole)
            {
                await roleManager.CreateAsync(new AppRole
                {
                    Id = Tools.CreateGuidStr(),
                    Name = "Yönetici",
                    Description = "Tüm alanlara erişim yetkisi bulunan kullancıı rolü"
                });
                var yonetici = await roleManager.FindByNameAsync("Yönetici");

                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.EventCallendar.View));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.EventCallendar.Create));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.EventCallendar.Update));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.EventCallendar.Cancel));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.EventCallendar.Complate));

                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.Project.View));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.Project.Create));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.Project.Update));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.Project.Cancel));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.Project.Complate));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.Project.Delete));

                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.SupportTicket.View));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.SupportTicket.Create));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.SupportTicket.Update));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.SupportTicket.Complate));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.SupportTicket.TransferToUser));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.SupportTicket.GetItOn));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.SupportTicket.Start));

                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.ManageUser.ViewDetail));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.ManageUser.ViewList));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.ManageUser.Create));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.ManageUser.Update));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.ManageUser.ChangeStatus));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.ManageUser.Authorize));

                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.CrmFirm.Sencron));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.CrmFirm.Update));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.CrmFirm.View));

                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.LogoCrmFirmAndContact.View));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Sencron));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Update));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Remove));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.LogoCrmFirmAndContact.TicketStatusChange));

                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.HelpDesc.ViewSolitions));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.HelpDesc.Create));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.HelpDesc.Update));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.HelpDesc.ChangeStatus));

                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.Module.Create));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.Module.Update));
                await roleManager.AddClaimAsync(yonetici, new Claim("Permission", Permissions.Module.ChangeStatus));
            }


            var logoDestekRole = await roleManager.RoleExistsAsync("Logo Destek");
            if (!logoDestekRole)
            {
                await roleManager.CreateAsync(new AppRole
                {
                    Id = Tools.CreateGuidStr(),
                    Name = "Logo Destek",
                    Description = "Logo destek ekibi rol tanımı"
                });



                var logoRole = await roleManager.FindByNameAsync("Logo Destek");

                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.EventCallendar.View));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.EventCallendar.Create));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.EventCallendar.Update));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.EventCallendar.Cancel));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.EventCallendar.Complate));

                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.Project.View));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.Project.Create));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.Project.Update));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.Project.Cancel));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.Project.Complate));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.Project.Delete));

                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.SupportTicket.View));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.SupportTicket.Create));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.SupportTicket.Update));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.SupportTicket.Complate));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.SupportTicket.TransferToUser));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.SupportTicket.GetItOn));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.SupportTicket.Start));

                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.CrmFirm.Sencron));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.CrmFirm.Update));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.CrmFirm.View));

                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.LogoCrmFirmAndContact.View));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Sencron));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Update));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Remove));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.LogoCrmFirmAndContact.TicketStatusChange));

                
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.HelpDesc.ViewSolitions));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.HelpDesc.Create));
                await roleManager.AddClaimAsync(logoRole, new Claim("Permission", Permissions.HelpDesc.Update));

            }


            var TeknikRole = await roleManager.RoleExistsAsync("Teknik");

            if (!TeknikRole)
            {
                await roleManager.CreateAsync(new AppRole
                {
                    Id = Tools.CreateGuidStr(),
                    Name = "Teknik",
                    Description = "Donanım ve Network teknik destek ekbi role tanımı"
                });

                var teknikRole = await roleManager.FindByNameAsync("Teknik");

                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.EventCallendar.View));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.EventCallendar.Create));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.EventCallendar.Update));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.EventCallendar.Cancel));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.EventCallendar.Complate));

                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.View));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.Create));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.Update));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.Cancel));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.Complate));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.Delete));


                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.View));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.Create));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.Update));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.Cancel));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.Complate));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.Project.Delete));

                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.SupportTicket.View));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.SupportTicket.Create));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.SupportTicket.Update));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.SupportTicket.Complate));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.SupportTicket.TransferToUser));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.SupportTicket.GetItOn));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.SupportTicket.Start));

                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.CrmFirm.Sencron));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.CrmFirm.View));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.CrmFirm.Update));

                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.LogoCrmFirmAndContact.View));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Sencron));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Update));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Remove));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.LogoCrmFirmAndContact.TicketStatusChange));

                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.HelpDesc.ViewSolitions));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.HelpDesc.Create));
                await roleManager.AddClaimAsync(teknikRole, new Claim("Permission", Permissions.HelpDesc.Update));


            }

            var YazilimciRole = await roleManager.RoleExistsAsync("Yazılım");
            if (!YazilimciRole)
            {
                await roleManager.CreateAsync(new AppRole
                {
                    Id = Tools.CreateGuidStr(),
                    Name = "Yazılım",
                    Description = "Yazılım geliştirme departmanı rol grubu"
                });

                var Yazılım = await roleManager.FindByNameAsync("Yazılım");

                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.EventCallendar.View));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.EventCallendar.Create));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.EventCallendar.Update));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.EventCallendar.Cancel));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.EventCallendar.Complate));

                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.Project.View));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.Project.Create));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.Project.Update));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.Project.Cancel));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.Project.Complate));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.Project.Delete));

                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.SupportTicket.View));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.SupportTicket.Create));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.SupportTicket.Update));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.SupportTicket.Complate));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.SupportTicket.TransferToUser));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.SupportTicket.GetItOn));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.SupportTicket.Start));

                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.ViewDetail));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.ViewList));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.Create));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.Update));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.ChangeStatus));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.Authorize));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.ViewRoleList));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.CreateRole));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.UpdateRole));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.DeleteRole));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.ManageUser.Claims));

                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.CrmFirm.Sencron));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.CrmFirm.View));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.CrmFirm.Update));

                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.LogoCrmFirmAndContact.View));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Sencron));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Update));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.LogoCrmFirmAndContact.Remove));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.LogoCrmFirmAndContact.TicketStatusChange));

                
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.HelpDesc.ViewSolitions));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.HelpDesc.Create));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.HelpDesc.Update));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.HelpDesc.ChangeStatus));

                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.Module.Create));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.Module.Update));
                await roleManager.AddClaimAsync(Yazılım, new Claim("Permission", Permissions.Module.ChangeStatus));
            }

            if (!userManager.Users.Any())
            {
                var user1 = new AppUser
                {
                    Name = "Erkan",
                    Lastname = "Dirikcan",
                    Id = Tools.CreateGuidStr(),
                    Email = "erkan@sistem-bilgisayar.com.tr",
                    Oid = "B3EC9493-C829-4BF7-A700-0AEA284EC6EB",
                    EmailConfirmed = true,
                    PhoneNumber = "538 300 6313",
                    PhoneNumberConfirmed = true,
                    Status = UserStatusEnum.Active,
                    Title = "Yazılım Geliştirme Uzmanı",
                    UserName = "erkan@sistem-bilgisayar.com.tr",
                    SKey = Tools.GuidStringToBigIntPositive(Tools.CreateGuidStr()).ToString(),

                };
                var u1Res = await userManager.CreateAsync(user1, "As26560770!");
                var u1 = await userManager.FindByIdAsync(user1.Id);
                await userManager.AddToRoleAsync(u1, "Yazılım");

                var user2 = new AppUser
                {
                    Name = "Murat",
                    Lastname = "ERGÜN",
                    Id = Tools.CreateGuidStr(),
                    Email = "murat@sistem-bilgi.com",
                    Oid = "DC1DB583-5044-456C-80ED-935EA2B7DE27",
                    EmailConfirmed = true,
                    PhoneNumber = "532 995 1212",
                    PhoneNumberConfirmed = true,
                    Status = UserStatusEnum.Active,
                    Title = "Yönetici",
                    UserName = "murat@sistem-bilgi.com",
                    SKey = Tools.GuidStringToBigIntPositive(Tools.CreateGuidStr()).ToString()

                };
                var u2Res = await userManager.CreateAsync(user2, "As987987!");
                var u2 = await userManager.FindByIdAsync(user2.Id);
                await userManager.AddToRoleAsync(u2, "Yönetici");
            }

            
        }
    }
}
