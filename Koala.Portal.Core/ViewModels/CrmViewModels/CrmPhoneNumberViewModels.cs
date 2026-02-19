namespace Koala.Portal.Core.ViewModels.CrmViewModels
{
    public class CrmPhoneNumberInfoViewModel
    {
        public string Oid { get; set; }
        public string? RelatedFirm { get; set; }
        public string? RelatedContact { get; set; }
        public string? AreaCode { get; set; }
        public string? Number { get; set; }
        public string? Phonetype { get; set; }

        //public CrmPhoneFirmInfoViewModel? ReleatedFirm { get; set; }
        //public CrmPhoneFirmContactInfoViewModel? ReleatedFirmContact { get; set; }

    }
    public class CreateCrmPhoneViewModel
    {
        public string Oid { get; set; }
        public string? RelatedFirm { get; set; }
        public string? RelatedContact { get; set; }
        public string? AreaCode { get; set; }
        public string? Number { get; set; }
        public string? Extension { get; set; }

        //public CrmPhoneFirmInfoViewModel? ReleatedFirm { get; set; }
        //public CrmPhoneFirmContactInfoViewModel? ReleatedFirmContact { get; set; }

    }
    public class CrmPhonesInfoViewModel
    {
        public string Oid { get; set; }
        public string? AreaCode { get; set; }

        public string? Number { get; set; }

        public string? Extension { get; set; }
        public bool? IsDefaultPhone { get; set; }
        public override string ToString()
        {
            return $"{AreaCode}{Number}";
        }
    }
    public class UpdateCrmPhoneViewModel
    {
        public string Oid { get; set; }
        public string? RelatedFirm { get; set; }
        public string? RelatedContact { get; set; }
        public string? AreaCode { get; set; }
        public string? Number { get; set; }
        public string? Extension { get; set; }

        //public CrmPhoneFirmInfoViewModel? ReleatedFirm { get; set; }
        //public CrmPhoneFirmContactInfoViewModel? ReleatedFirmContact { get; set; }

    }
}
