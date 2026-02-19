using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class ClaimProfile:Profile
    {
        public ClaimProfile()
        {
            CreateMap<Claims, ClaimListViewModels>().ReverseMap();
            CreateMap<Claims,CreateClaimViewModels>().ReverseMap();
            CreateMap<Claims,UpdateClaimViewModels>().ReverseMap();
            CreateMap<Claims, ClaimListForRoleViewModels>().ReverseMap();
            CreateMap<Claims, ClaimListForModuleViewModels>().ReverseMap();
        }
    }
}
