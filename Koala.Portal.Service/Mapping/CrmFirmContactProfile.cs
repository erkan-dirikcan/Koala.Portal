using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class CrmFirmContactProfile : Profile
    {
        public CrmFirmContactProfile()
        {
            //====================================Local ==============================================
            CreateMap<CrmFirmContact, CreateCrmFirmContacViewModel>().ReverseMap();
            //CreateMap<CrmFirmContact, CrmFirmContactListViewModel>()
            //    .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.GetFullName()));

            CreateMap<CrmFirmContact, CrmFirmContactListViewModel>()
               .ForMember(dest=>dest.Firm,opt=>opt.MapFrom(x=>x.GetFirmDisplayName()))
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.GetFullName()));

            CreateMap<CrmFirmContact, CrmFirmContactDetailViewModel>();
            CreateMap<CrmFirmContact, DetailedInfoCrmFirmContactViewModel>()
                .ForMember(dest => dest.Oid, opts => opts.MapFrom(x => x.Oid.ToString()));

            //====================================CRM ================================================
            CreateMap<MT_Contact, CreateCrmFirmContacViewModel>()
                .ForMember(dest => dest.Oid, opt => opt.MapFrom(x => x.Oid.ToString()))
                .ForMember(dest => dest.FirmId, opt => opt.MapFrom(x => x.RelatedFirm.ToString()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dest => dest.InUse, opt => opt.MapFrom(x => x.InUse))
                .ForMember(dest => dest.SupportTicket, opt => opt.MapFrom(x => x._MXN_InUse ?? false))
                .ForMember(dest => dest.Phones, ops => ops.MapFrom(x => x.PO_Phone_Number));

            CreateMap<MT_Contact, DetailedInfoCrmFirmContactViewModel>()
                .ForMember(dest => dest.Oid, opt => opt.MapFrom(x => x.Oid.ToString()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dest => dest.Phones, ops => ops.MapFrom(x => x.PO_Phone_Number));

            CreateMap<MT_Contact, GetCrmEmailInfoViewModel>();
              


        }
    }
}
