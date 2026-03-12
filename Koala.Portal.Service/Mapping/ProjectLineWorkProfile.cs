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
            CreateMap<ProjectLineWork, AddProjectLineWorkViewModel>()
                .ForMember(dest => dest.ReleatedSupport, opt => opt.Ignore())
                .ForMember(dest => dest.CreateUserId, opt => opt.MapFrom(src => src.CreateUser));
            CreateMap<AddProjectLineWorkViewModel, ProjectLineWork>()
                .ForMember(dest => dest.WorkPersons, opt => opt.Ignore()) // WorkPersons manuel oluşturulacak
                .ForMember(dest => dest.ReleatedSupportId, opt => opt.Ignore())
                .ForMember(dest => dest.ReleatedSupportOid, opt => opt.Ignore())
                .ForMember(dest => dest.CreateUser, opt => opt.MapFrom(src => src.CreateUserId));
            CreateMap<ProjectLineWork, UpdateProjectLineWorkViewModel>();
            CreateMap<UpdateProjectLineWorkViewModel, ProjectLineWork>()
                .ForMember(dest => dest.WorkPersons, opt => opt.MapFrom(src => src.WorkPersons ?? new List<AddProjectPersonViewModel>()))
                .ForMember(dest => dest.ReleatedSupportId, opt => opt.Ignore())
                .ForMember(dest => dest.ReleatedSupportOid, opt => opt.Ignore());
            CreateMap<ProjectLineWork, ProjectLineWorkDetailViewModel>();
            CreateMap<ProjectLineWork, ProjectLineWorkListViewModel>();
            CreateMap<ProjectLineWork, ProjectLineWorkChangeStateViewModel>();
            CreateMap<ProjectLineWork, ProjectLineWorkComplateViewModel>();

            // DTO Mappings for API
            CreateMap<ProjectLineWork, ProjectLineWorkDto>();
            CreateMap<CreateProjectLineWorkDto, AddProjectLineWorkViewModel>()
                .ForMember(dest => dest.ReleatedSupport, opt => opt.Ignore())
                .ForMember(dest => dest.WorkPersons, opt => opt.MapFrom(src => new List<Koala.Portal.Core.ViewModels.PortalViewModels.AddProjectPersonViewModel>()));
            CreateMap<UpdateProjectLineWorkDto, UpdateProjectLineWorkViewModel>()
                .ForMember(dest => dest.WorkPersons, opt => opt.MapFrom(src => new List<Koala.Portal.Core.ViewModels.PortalViewModels.AddProjectPersonViewModel>()));
        }
    }
}
