using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class CrmFirmProfile : Profile
    {
        public CrmFirmProfile()
        {
            //====================================CRM==============================================
            #region CRM Mapping Tabloları
            CreateMap<MT_Firm, InfoCrmFirmViewModel>()
                 .ForMember(dest => dest.Oid, opts => opts.MapFrom(x => x.Oid.ToString()))
                 .ForMember(dest => dest.Code, opts => opts.MapFrom(x => x.FirmCode))
                 .ForMember(dest => dest.Title, opts => opts.MapFrom(x => x.FirmTitle))
                 .ForMember(dest => dest.Contacts, opts => opts.MapFrom(x => x.MT_Contact))
                 .ForMember(dest => dest.Phones, opts => opts.MapFrom(x => x.PO_Phone_Number));

            CreateMap<MT_Firm, CreateCrmFirmViewModel>()
                .ForMember(dest => dest.Oid, opts => opts.MapFrom(x => x.Oid.ToString()))
                .ForMember(dest => dest.Code, opts => opts.MapFrom(x => x.FirmCode))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(x => x.FirmTitle))
                .ForMember(dest => dest.Phone, opts => opts.MapFrom(x => x.Phones))
                .ForMember(dest => dest.InUse, opts => opts.MapFrom(x => x.InUse))
                .ForMember(dest => dest.Contacts, ops => ops.MapFrom(x => x.MT_Contact))
                .ForMember(dest => dest.Phones, ops => ops.MapFrom(x => x.PO_Phone_Number));

            CreateMap<MT_Firm, SupportListInfoCrmFirmViewModel>()
                .ForMember(dest => dest.Code, opts => opts.MapFrom(x => x.FirmCode))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(x => x.FirmTitle))
                .ForMember(dest => dest.Oid, opts => opts.MapFrom(x => x.Oid.ToString()))
                .ForMember(dest => dest.Phone, opts => opts.MapFrom(x => x.Phones))
                .ForMember(dest => dest.InUse, opts => opts.MapFrom(x => x.InUse))
                .ForMember(dest => dest.LogoSupport, opts => opts.MapFrom(x => x.FirmLogoBakimAnlasmasi))
                .ForMember(dest => dest.LogoSupportExpDate, opts => opts.MapFrom(x => x.FirmLogoBakimBitisTarihi))
                .ForMember(dest => dest.NewLogoSupport, opts => opts.MapFrom(x => x.FirmYeniLogoBakimAnlasmasi))
                .ForMember(dest => dest.NewLogoSupportExpDate, opts => opts.MapFrom(x => x.FirmYeniLogoBakimBitisTarihi))
                .ForMember(dest => dest.TecnicalSupport, opts => opts.MapFrom(x => x.FirmTeknikBakimAnlasmasi))
                .ForMember(dest => dest.TecnicalSupportExpDate, opts => opts.MapFrom(x => x.FirmTeknikBakimBitisTarihi))
                .ForMember(dest => dest.NewTecnicalSupport, opts => opts.MapFrom(x => x.FirmYeniDonanimBakimAnlasmasi))
                .ForMember(dest => dest.Contacts, opts => opts.MapFrom(x => x.MT_Contact))
                .ForMember(dest => dest.Phones, opts => opts.MapFrom(x => x.PO_Phone_Number))
                .ForMember(dest => dest.NewTecnicalSupportExpDate, opts => opts.MapFrom(x => x.FirmYeniDonanimBakimBitisTarihi));

            CreateMap<MT_Firm, FirmSupportStatusViewModel>()
                .ForMember(dest => dest.LogoSupport, opts => opts.MapFrom(x => x.FirmLogoBakimAnlasmasi))
                .ForMember(dest => dest.LogoSupportExpDate, opts => opts.MapFrom(x => x.FirmLogoBakimBitisTarihi))
                .ForMember(dest => dest.NewLogoSupport, opts => opts.MapFrom(x => x.FirmYeniLogoBakimAnlasmasi))
                .ForMember(dest => dest.NewLogoSupportExpDate, opts => opts.MapFrom(x => x.FirmYeniLogoBakimBitisTarihi))
                .ForMember(dest => dest.TecnicalSupport, opts => opts.MapFrom(x => x.FirmTeknikBakimAnlasmasi))
                .ForMember(dest => dest.TecnicalSupportExpDate, opts => opts.MapFrom(x => x.FirmTeknikBakimBitisTarihi))
                .ForMember(dest => dest.NewTecnicalSupport, opts => opts.MapFrom(x => x.FirmYeniDonanimBakimAnlasmasi))
                .ForMember(dest => dest.NewTecnicalSupportExpDate, opts => opts.MapFrom(x => x.FirmYeniDonanimBakimBitisTarihi));
            CreateMap<MT_Firm, UpdateCrmFirmViewModel>()
                .ForMember(dest => dest.Oid, opts => opts.MapFrom(x => x.Oid.ToString()))
                .ForMember(dest => dest.Code, opts => opts.MapFrom(x => x.FirmCode))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(x => x.FirmTitle))
                .ForMember(dest => dest.Phone, opts => opts.MapFrom(x => x.Phones))
                .ForMember(dest => dest.InUse, opts => opts.MapFrom(x => x.InUse))
                .ForMember(dest => dest.Contacts, ops => ops.MapFrom(x => x.MT_Contact))
                .ForMember(dest => dest.Phones, ops => ops.MapFrom(x => x.PO_Phone_Number));
            #endregion


            //====================================Local==============================================

            #region Local Mapping Tabloları
            CreateMap<CrmFirm, CreateCrmFirmViewModel>().ReverseMap();

            CreateMap<CrmFirm, CrmFirmListViewModel>().ReverseMap();

            CreateMap<CrmFirm, InfoCrmFirmViewModel>()
                .ForMember(dest => dest.Oid, opts => opts.MapFrom(x => x.Oid.ToString()))
                .ForMember(dest => dest.Phones, opts => opts.MapFrom(x => x.Phones));

            CreateMap<CreateCrmFirmViewModel, CrmFirm>()
            .ForMember(dest => dest.Phones, opts => opts.MapFrom(x => x.Phones))
            .ForMember(dest => dest.Contacts, opts => opts.MapFrom(x => x.Contacts)); 

            #endregion
        }
    }
}