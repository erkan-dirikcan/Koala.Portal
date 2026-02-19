using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class VacationHistoryProfile:Profile
    {
        public VacationHistoryProfile()
        {
            CreateMap<VacationHistory, AddVacationHistoryViewModel>().ReverseMap();
               
        }
    }
}
