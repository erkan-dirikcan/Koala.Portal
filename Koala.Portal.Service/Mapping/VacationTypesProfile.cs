using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class VacationTypesProfile:Profile
    {
        public VacationTypesProfile()
        {
            CreateMap<VacationTypes, VacationTypesViewModel>().ReverseMap();
            CreateMap<VacationTypes, VacationTypesCreateViewModel>().ReverseMap();
            CreateMap<VacationTypes, VacationTypesChangeStatusViewModel>().ReverseMap();
        }
    }
}
