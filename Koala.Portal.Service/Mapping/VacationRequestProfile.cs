using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class VacationRequestProfile:Profile
    {
        public VacationRequestProfile()
        {
              CreateMap<VacationRequest, VacationRequestListViewModel>()
               .ForMember(dest => dest.VacationType, opt => opt.MapFrom(x => x.VacationType.Name))
               .ForMember(dest => dest.User, opt => opt.MapFrom(x => $"{x.User.Name} {x.User.Lastname}"));

            CreateMap<VacationRequest, VacationRequestDetailViewModel>()
               .ForMember(dest => dest.VacationType, opt => opt.MapFrom(x => x.VacationType.Name))
               .ForMember(dest => dest.User, opt => opt.MapFrom(x => $"{x.User.Name} {x.User.Lastname}"));
            CreateMap<VacationRequest, VacationRequestCreateViewModel>().ReverseMap();
            CreateMap<VacationRequest, VacationRequestRevisionViewModel>().ReverseMap();
            CreateMap<VacationRequest, VacationRequestRevisionRequestViewModel>().ReverseMap();
            CreateMap<VacationRequest, VacationRequestCancelViewModel>().ReverseMap();
        }
    }
}