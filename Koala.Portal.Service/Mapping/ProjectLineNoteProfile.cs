using AutoMapper;
using Koala.Portal.Core.DTOs;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class ProjectLineNoteProfile:Profile
    {
        public ProjectLineNoteProfile()
        {
            CreateMap<ProjectLineNote, ProjectLineNoteViewModel>()
                .ForMember(dest=>dest.ProjectLineName,opts=>opts.MapFrom(x=>x.ProjectLine.Title));
            CreateMap<ProjectLineNote, AddProjectLineNoteViewModel>().ReverseMap();
            CreateMap<ProjectLineNote, UpdateProjectLineNoteViewModel>().ReverseMap();

            // DTO Mappings for API
            CreateMap<ProjectLineNote, ProjectLineNoteDto>();
            CreateMap<CreateProjectLineNoteDto, AddProjectLineNoteViewModel>();
            CreateMap<UpdateProjectLineNoteDto, UpdateProjectLineNoteViewModel>();
        }
    }
}
