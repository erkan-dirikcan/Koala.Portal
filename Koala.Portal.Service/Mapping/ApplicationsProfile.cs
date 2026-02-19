using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping;

public class ApplicationsProfile:Profile
{
    public ApplicationsProfile()
    {
        CreateMap<Applications, ApplicationsListViewModel>().ReverseMap();
        CreateMap<Applications, CreateApplicationsViewModel>().ReverseMap();
        CreateMap<Applications, UpdateApplicationsViewModel>().ReverseMap();
        CreateMap<Applications, DetailApplicationsViewModel>().ReverseMap();
        CreateMap<Applications, ApplicationsChangeStatusViewModel>().ReverseMap();
        CreateMap<Applications, ApplicationsAddExpDateViewModel>().ReverseMap();
    }
}