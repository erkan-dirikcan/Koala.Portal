using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<AppRole, RoleListViewModel>().ReverseMap();
            CreateMap<AppRole, CreateRoleViewModel>().ReverseMap();
            CreateMap<AppRole, UpdateRoleViewModel>().ReverseMap();
        }
    }
}
