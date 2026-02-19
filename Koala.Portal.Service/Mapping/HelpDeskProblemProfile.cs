using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class HelpDeskProblemProfile:Profile
    {
        public HelpDeskProblemProfile()
        {
            CreateMap<HelpDeskProblem, HelpDeskProblemInfoViewModels>()
                .ReverseMap();


            CreateMap<HelpDeskProblem,HelpDeskProblemDetailInfoViewModels>()
                .ReverseMap();
            
            
            CreateMap<HelpDeskProblem,HelpDeskProblemChangeStatusViewModel>().ReverseMap();
            CreateMap<HelpDeskProblem,HelpDeskProblemCreateViewModel>().ReverseMap();
            CreateMap<HelpDeskProblem,HelpDeskProblemUpdateViewModel>().ReverseMap();
            CreateMap<HelpDeskProblem,HelpDeskProblemViewsCountViewModel>().ReverseMap();
        }
    }
}
