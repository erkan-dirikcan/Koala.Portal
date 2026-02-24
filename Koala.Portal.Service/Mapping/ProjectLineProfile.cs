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
                .ForMember(dest=>dest.LineOfficialId, opt=>opt.MapFrom(x=>x.LineOfficialId))
                .ForMember(dest=>dest.LineFirmOfficialId, opt=>opt.MapFrom(x=>x.LineFirmOfficialId))
                .ForMember(dest=>dest.LineOfficial, opt=>opt.MapFrom(x=>x.GetManagerFullName()))
                .ForMember(dest=>dest.LineFirmOfficial, opt=>opt.MapFrom(x=>x.GetFirmPersonFullName()))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(x => x.GetDueDateStr()))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(x => x.GetStartDateStr()))
                .ForMember(dest => dest.RowOrder, opt => opt.MapFrom(x => x.RowOrdwer));

            CreateMap<ProjectLine, ProjectLineDetailViewModel>()
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(x => x.GetDueDateStr()))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(x => x.GetStartDateStr()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(x => x.GetEndDateStr()));

            CreateMap<ProjectLine, UpdateProjectLineViewModel>().ReverseMap();
            CreateMap<AddProjectLineViewModel, ProjectLine>();
            CreateMap<ProjectLine, AddProjectLineViewModel>();
            CreateMap<ProjectLine, ProjectLineChangeStateStatusViewModel>();
            CreateMap<ProjectLine, ProjectLineComplateViewModel>();
        }
    }
}
