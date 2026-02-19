using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class HelpDeskCategoryProfile : Profile
    {
        public HelpDeskCategoryProfile()
        {
            CreateMap<HelpDeskCategory, HelpDeskCategoryInfoViewModels>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ReverseMap();
            CreateMap<HelpDeskCategory, HelpDeskCategoryChangeStatusViewModel>().ReverseMap();
            CreateMap<HelpDeskCategory, HelpDeskCategoryCreateViewModel>().ReverseMap();
            CreateMap<HelpDeskCategory, HelpDeskCategoryUpdateViewModel>().ReverseMap();

        }
    }
}
