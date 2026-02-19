using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectListViewModel>()
                .ForMember(dest => dest.ProjectManager, opts => opts.MapFrom(x => x.GetManagerFullName()))
                .ForMember(dest => dest.Firm, opts => opts.MapFrom(x => x.GetFirmDisplayName()))
                .ForMember(dest => dest.FirmPerson, opts => opts.MapFrom(x => x.GetFirmPersonFullName()))
                .ForMember(dest => dest.StartDate, opts => opts.MapFrom(x => x.GetStartDateStr()))
                .ForMember(dest => dest.DueDate, opts => opts.MapFrom(x => x.GetDueDateStr()));
            CreateMap<Project, AddProjectViewModel>().ReverseMap();
            CreateMap<Project, UpdateProjectViewModel>().ReverseMap();
            CreateMap<Project, ProjectDetailViewModel>().ReverseMap();
            CreateMap<Project, ProjectChanegeStatusViewModel>().ReverseMap();
            CreateMap<Project, ProjectChanegeStateStatusViewModel>().ReverseMap();

        }
    }
}
