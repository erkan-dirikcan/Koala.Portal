namespace Koala.Portal.Core.ViewModels.CrmViewModels
{
    public class CreateCrmFirmContacViewModel
    {

        public string Oid { get; set; }
        public string FirmId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool InUse { get; set; } = false;
        public bool SupportTicket { get; set; } = false;
        public List<CreateCrmPhoneViewModel> Phones { get; set; }

        //public virtual CrmFirm Firm { get; set; }
        //public virtual ICollection<Project> PersonProjects { get; set; }
    }
    public class UpdateCrmFirmContactViewModel
    {
        public string Oid { get; set; }
        //public virtual CrmFirm Firm { get; set; }
        //public virtual ICollection<Project> PersonProjects { get; set; }
    }
    public class DeleteCrmFirmContactViewModel
    {
        public string Id { get; set; }
        //public virtual CrmFirm Firm { get; set; }
        //public virtual ICollection<Project> PersonProjects { get; set; }
    }
   
    public class DetailedInfoCrmFirmContactViewModel
    {
        public string Oid { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? EmailAddress1 { get; set; }
        public string? EmailAddress2 { get; set; }
        public string? EmailAddress3 { get; set; }
        public List<CrmPhonesInfoViewModel> Phones { get; set; }
    }
    public class CrmPhoneFirmContactInfoViewModel
    {
        public string Oid { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress1 { get; set; }
        public string? EmailAddress2 { get; set; }
        public string? EmailAddress3 { get; set; }

    }

    public class CrmFirmContactListViewModel
    {
        public string Id { get; set; }
        public string Oid { get; set; }
        public string Firm { get; set; }
        public string FullName { get; set; }
    }

    public class CrmFirmContactDetailViewModel
    {
        public string Id { get; set; }
        public string Oid { get; set; }
        public string FirmId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{Name} {LastName}";
        public bool InUse { get; set; } = false;
        public bool SupportTicket { get; set; } = false;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public CrmFirmListViewModel Firm { get; set; }
    }

    public class GetCrmEmailInfoViewModel()
    {
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
    }
    public class UpdateCrmEmailInfoViewModel()
    {
        public string Oid { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
    }
}