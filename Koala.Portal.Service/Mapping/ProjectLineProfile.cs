using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class ProjectLineProfile :Profile
    {
        public ProjectLineProfile()
        {
            CreateMap<ProjectLine, ProjectLineListViewModel>()
                .ForMember(dest=>dest.Project,opt=>opt.MapFrom(x=>x.Project.ProjectName))
                .ForMember(dest=>dest.LineOfficial, opt=>opt.MapFrom(x=>x.GetManagerFullName()))
                .ForMember(dest=>dest.LineFirmOfficial, opt=>opt.MapFrom(x=>x.GetFirmPersonFullName()))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(x => x.GetDueDateStr()))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(x => x.GetStartDateStr()));

            CreateMap<ProjectLine, ProjectLineDetailViewModel>()
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(x => x.GetDueDateStr()))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(x => x.GetStartDateStr()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(x => x.GetEndDateStr()));

            CreateMap<ProjectLine, UpdateProjectLineViewModel>();
            CreateMap<ProjectLine, AddProjectLineViewModel>();
            CreateMap<ProjectLine, ProjectLineChangeStateStatusViewModel>();
            CreateMap<ProjectLine, ProjectLineComplateViewModel>();
        }
    }
}
