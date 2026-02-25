using AutoMapper;
using Koala.Portal.Core.DTOs;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class ProjectLineWorkProfile:Profile
    {
        public ProjectLineWorkProfile()
        {
            CreateMap<ProjectLineWork, AddProjectLineWorkViewModel>();
            CreateMap<ProjectLineWork, UpdateProjectLineWorkViewModel>();
            CreateMap<ProjectLineWork, ProjectLineWorkDetailViewModel>();
            CreateMap<ProjectLineWork, ProjectLineWorkListViewModel>();
            CreateMap<ProjectLineWork, ProjectLineWorkChangeStateViewModel>();
            CreateMap<ProjectLineWork, ProjectLineWorkComplateViewModel>();

            // DTO Mappings for API
            CreateMap<ProjectLineWork, ProjectLineWorkDto>();
            CreateMap<CreateProjectLineWorkDto, AddProjectLineWorkViewModel>();
            CreateMap<UpdateProjectLineWorkDto, UpdateProjectLineWorkViewModel>();
        }
    }
}
