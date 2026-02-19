namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class AgendaListViewModel
    {
        public string Id { get; set; }
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class CreateAgendaViewModel
    {
        public string AgendaType { get; set; }
        public string EventCode { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public virtual List<string> Users { get; set; }
        public virtual List<string> AgendaFixtures { get; set; }
        public virtual List<string> FirmOfficials { get; set; }
        public string ProjectId { get; set; }
        public string TicketOid { get; set; }
        public string FirmOid { get; set; }
        public string Description { get; set; }
        public string NoteForCustomer { get; set; }
    }
    public class AgendaDetailViewModel
    {
        public string Id { get; set; }
        public string EventCode { get; set; }
        public string AgendaType { get; set; }
        public string AgendaTypeId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Title { get; set; }
        public string Firm { get; set; }
        public string FirmId { get; set; }
        public string Location { get; set; }
        public string Project { get; set; }
        public string ProjectId { get; set; }
        public string Ticket { get; set; }
        public string TicketId { get; set; }
        public string Description { get; set; }
        public string FontColor { get; set; }
        public string BackColor { get; set; }
        public string NoteForCustomer { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsComplated { get; set; }
        public List<AgendaDetailFixtureViewModel> AgendaFixtures { get; set; }
        public List<AgendaDetailFirmOfficialsViewModel> FirmOfficials { get; set; }
        public List<AgendaDetailUsersViewModel> Users { get; set; }
    }
    public class AgendaDetailFirmOfficialsViewModel
    {
        public string Id { get; set; }
        public string Oid { get; set; }
        public string FullName { get; set; }
    }
    public class AgendaDetailUsersViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
    }
    public class AgendaDetailFixtureViewModel
    {
        public string Id { get; set; }
        public string Fixture { get; set; }
        public bool IsVehicle { get; set; }
        public int? StartKm { get; set; }
        public int? EndKm { get; set; }
    }
    public class UpdateAgendaViewModel
    {
        public string Id { get; set; }
        public string AgendaType { get; set; }
        public string EventCode { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ProjectId { get; set; }
        public string TicketOid { get; set; }
        public string FirmOid { get; set; }
        public string Description { get; set; }
        public string NoteForCustomer { get; set; }
        public virtual List<string> Users { get; set; }
        public virtual List<string> AgendaFixtures { get; set; }
        public virtual List<string> FirmOfficials { get; set; }
    }
    public class CancelAgendaViewModel
    {
        public string Id { get; set; }
        public string CancelDesc { get; set; }
    }
    public class ComplateAgendaViewModel
    {
        public string Id { get; set; }
        public string ComplatedDesc { get; set; }
        public string NoteForCustomer { get; set; }
        public List<AgendaDetailFixtureViewModel> Vehicles { get; set; }
    }
    public class AgendaChangeDateViewModel
    {
        public string Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
