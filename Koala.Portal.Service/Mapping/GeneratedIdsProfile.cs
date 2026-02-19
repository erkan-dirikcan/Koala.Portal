using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class GeneratedIdsProfile : Profile
    {
        public GeneratedIdsProfile()
        {
            CreateMap<GeneratedIds, GetGeneratedIdsListViewModel>()
            .ForMember(dest => dest.ModuleName, opt => opt.MapFrom(x => x.Module.DisplayName)).ReverseMap();
            CreateMap<GeneratedIds, CreateGeneratedIdsViewModel>().ReverseMap();
            CreateMap<GeneratedIds, UpdateGeneratedIdsViewModel>().ReverseMap();
        }
    }
}
