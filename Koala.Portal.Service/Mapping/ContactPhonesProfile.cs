using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class ContactPhonesProfile:Profile
    {
        public ContactPhonesProfile()
        {
            //====================================CRM==============================================
            CreateMap<PO_Phone_Number,CrmPhonesInfoViewModel>()
                .ForMember(dest=>dest.Oid,opt=>opt.MapFrom(x=>x.Oid.ToString()));

            CreateMap<PO_Phone_Number,CreateCrmPhoneViewModel>()
                .ForMember(dest=>dest.Oid,opt=>opt.MapFrom(x=>x.Oid.ToString()));
           
            CreateMap<PO_Phone_Number, CrmPhoneNumberInfoViewModel>()
                .ForMember(dest=>dest.Oid,opt=>opt.MapFrom(x=>x.Oid.ToString()));
            
            CreateMap<CrmPhonesInfoViewModel,PO_Phone_Number > ()
               .ForMember(dest => dest.Oid, opt => opt.MapFrom(x => new Guid (x.Oid)));

            CreateMap<PO_Phone_Number,Firm3cxInfoViewModel>()
                .ForMember(dest=>dest.Oid,opt=>opt.MapFrom(x=>x.Oid.ToString()))
                .ForMember(dest=>dest.FirmCode,opt=>opt.MapFrom(x=>x.RelatedFirmNavigation!=null?x.RelatedFirmNavigation.FirmCode:"-"))
                .ForMember(dest=>dest.FirmTitle,opt=>opt.MapFrom(x=>x.RelatedFirmNavigation!=null?x.RelatedFirmNavigation.FirmTitle:"-"))
                .ForMember(dest=>dest.FirstName,opt=>opt.MapFrom(x=>x.RelatedContactNavigation!=null?x.RelatedContactNavigation.FirstName:"-"))
                .ForMember(dest=>dest.LastName,opt=>opt.MapFrom(x=>x.RelatedContactNavigation!=null?x.RelatedContactNavigation.LastName:"-"))
                .ForMember(dest=>dest.EmailAddress1,opt=>opt.MapFrom(x=>x.RelatedContactNavigation!=null?x.RelatedContactNavigation.EmailAddress1:""))
                .ForMember(dest=>dest.Number1,opt=>opt.MapFrom(x=>x.NumberFormat()))
                .ForMember(dest=>dest.UrlSlug,opt=>opt.MapFrom(x=>x.GetUrl()))
                .ForMember(dest=>dest.ContactId,opt=>opt.MapFrom(x=>x.RelatedContact.ToString()??""));
            //====================================Local==============================================


            CreateMap<CrmPhoneNumber, CreateCrmPhoneViewModel>().ReverseMap();
            CreateMap<CrmPhoneNumber, CrmPhonesInfoViewModel>().ReverseMap();
            CreateMap<CrmPhoneNumber, CrmPhoneNumberListViewModel>().ReverseMap();


        }
        
    }
}

