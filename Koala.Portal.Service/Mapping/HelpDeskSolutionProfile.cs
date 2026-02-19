using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;
namespace Koala.Portal.Service.Mapping
{
    public class HelpDeskSolutionProfile:Profile
    {
        public HelpDeskSolutionProfile()
        {
            CreateMap<HelpDeskSolution, HelpDeskSolitionInfoViewModels>()
                .ForMember(dest=>dest.HelpDeskProblemName,opt=>opt.MapFrom(x=>x.HelpDeskProblem.Title)).ReverseMap();
            CreateMap<HelpDeskSolution, HelpDeskSolitionInfoForProblemViewModels>();
            CreateMap<HelpDeskSolution, HelpDeskSolitionCreateViewModel>().ReverseMap();
            CreateMap<HelpDeskSolution, HelpDeskSolitionChangeStatusViewModel>().ReverseMap();
            CreateMap<HelpDeskSolution, HelpDeskSolitionUpdateViewModel>().ReverseMap();
            CreateMap<HelpDeskSolution, HelpDeskSolitionChangeLikeCountViewModel>().ReverseMap();

        }
    }
}
