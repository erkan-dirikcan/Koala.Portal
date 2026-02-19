using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class ApplicationLicencesProfile : Profile
    {
        public ApplicationLicencesProfile()
        {
            CreateMap<ApplicationLicences, ApplicationLicencesListViewModel>()
                .ForMember(dest => dest.ActiveUserCount, opts => opts.MapFrom(x => x.Applications.GetActiveUserCount()))
                .ForMember(dest => dest.MaxUserCount, opts => opts.MapFrom(x => x.Applications.MaxUserCount));

            CreateMap<ApplicationLicencesListViewModel, ApplicationLicences>();


            CreateMap<ApplicationLicences, ApplicationLicencesRequestViewModel>().ReverseMap();

        }
    }
}
