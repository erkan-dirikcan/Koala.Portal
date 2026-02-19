using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class CrmSupportProfile : Profile
    {
        public CrmSupportProfile()
        {
            CreateMap<MT_Ticket, CrmSupportListViewModel>()
                .ForMember(dest => dest.AssignedToOid, opt => opt.MapFrom(x => x.AssignedTo.ToString()))
                .ForMember(dest => dest.ActiveWorkingUserOid, opt => opt.MapFrom(x => x.ActiveWorkingUser.ToString()))
                .ForMember(dest => dest.TicketStateOid, opt => opt.MapFrom(x => x.TicketState.ToString()))
                .ForMember(dest => dest.AssignedDepartmentOid, opt => opt.MapFrom(x => x.AssignedDepartment.ToString()))
                .ForMember(dest => dest.TicketStateOid, opt => opt.MapFrom(x => x.TicketState.ToString()))
                .ForMember(dest => dest.FirmSpecCode5, opt => opt.MapFrom(x => x.TicketFirmNavigation.Auxiliary_Code5))
                .ForMember(dest => dest.TicketFirmOid, opt => opt.MapFrom(x => x.TicketFirm.ToString()))
                .ForMember(dest => dest.TicketContactOid, opt => opt.MapFrom(x => x.TicketContact.ToString()));
            
            CreateMap<CrmCreateSupportViewModel, MT_Ticket>()
                .ForMember(dest => dest.TicketFirm, opts => opts.MapFrom(x => x.Firm))
                .ForMember(dest => dest.TicketContact, opts => opts.MapFrom(x => x.Contact))
                .ForMember(dest => dest.TicketContact2, opts => opts.MapFrom(x => x.Contact2))
                .ForMember(dest => dest.AssignedDepartment, opts => opts.MapFrom(x => x.Department))
                .ForMember(dest => dest.AssignedTo, opts => opts.MapFrom(x => x.AssignedTo))
                .ForMember(dest => dest.TicketMainCategory, opts => opts.MapFrom(x => x.MainCategory))
                .ForMember(dest => dest.TicketSubCategory, opts => opts.MapFrom(x => x.SubCategory))
                .ForMember(dest => dest.TicketType, opts => opts.MapFrom(x => x.SupportType))
                .ForMember(dest => dest._CreatedBy, opts => opts.MapFrom(x => x.CreateUserOid))
                .ForMember(dest => dest.TicketAramaTarihi, opts => opts.MapFrom(x => x.CallDateTime()))
                .ForMember(dest => dest.Priority, opts => opts.MapFrom(x => (int)x.Priority))
                .ForMember(dest => dest.Notes, opts => opts.MapFrom(x => x.Description))
                .ForMember(dest => dest.DevamEdiyor, opts => opts.MapFrom(x => x.DevamEdiyor))
                .ForMember(dest => dest.TicketDescription, opts => opts.MapFrom(x => x.Description));

            CreateMap<MT_Ticket, CrmUpdateSupportInfoViewModel>()
                .ForMember(dest => dest.TicketMainCategory, opts => opts.MapFrom(x => x.TicketMainCategoryNavigation.TicketMainCategoryDescription))
                .ForMember(dest => dest.TicketSubCategory, opts => opts.MapFrom(x => x.TicketSubCategoryNavigation.TicketSubCategoryDescription))
                .ForMember(dest => dest.TicketType, opts => opts.MapFrom(x => x.TicketType))
                .ForMember(dest => dest.TicketFirm, opts => opts.MapFrom(x => x.TicketFirmNavigation.FirmTitle))
                .ForMember(dest => dest.TicketContact, opts => opts.MapFrom(x => x.TicketContactNavigation.FullName))
                .ForMember(dest => dest.AssignedDepartment, opts => opts.MapFrom(x => x.AssignedDepartmentNavigation.DepartmentName))
                .ForMember(dest => dest.AssignedTo, opts => opts.MapFrom(x => x.AssignedToNavigation.Caption));

            CreateMap<MT_Ticket, CrmFirmOpenSupportViewModel>()
                .ForMember(dest => dest.TicketAramaTarihi, opts => opts.MapFrom(x => x.TicketAramaTarihi))
                .ForMember(dest => dest.AssignedTo, opts => opts.MapFrom(x => x.AssignedToNavigation.Caption))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(x => x.Notes));
        }


    }
}
