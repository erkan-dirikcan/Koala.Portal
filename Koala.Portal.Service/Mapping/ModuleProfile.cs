using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class ModuleProfile : Profile
    {
        public ModuleProfile()
        {
            CreateMap<Module, GetModuleListViewModels>()
                .ForMember(dest => dest.ModuleClaims, opt => opt.MapFrom(x => x.Claims))
            .ReverseMap();
            CreateMap<Module, GetModuleDetailViewModels>().ReverseMap();
            CreateMap<Module, CreateModuleListViewModels>().ReverseMap();
            CreateMap<Module, UpdateModuleViewModels>().ReverseMap()
                .ForMember(dest=>dest.GeneratedIds,opts=>opts.MapFrom(x=>x.GeneratedIds))
                .ForMember(dest=>dest.Claims,opts=>opts.MapFrom(x=>x.Claims));
        }
    }
}
