using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class ApplicationFirmProfile : Profile
    {
        public ApplicationFirmProfile()
        {
            CreateMap<ApplicationFirms, AddApplicationFirmsViewModel>().ReverseMap();
            CreateMap<ApplicationFirms, GetApplicationFirmListViewModel>().ReverseMap();
        }
    }
}
