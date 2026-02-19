using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class ApplicationModulesProfile:Profile
    {
        public ApplicationModulesProfile()
        {
            CreateMap<ApplicationModules, ApplicationModulesListViewModel>().ReverseMap();
            CreateMap<ApplicationModules, CreateApplicationModulesViewModel>().ReverseMap();
            CreateMap<ApplicationModules, ApplicationModulesDecryptedViewModel>().ReverseMap();
        }
    }
}
