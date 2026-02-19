using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class Agenda
    {
        public Agenda()
        {
            Users = new HashSet<AgendaUsers>();
            AgendaFixtures = new HashSet<AgendaFixtures>();
            FirmOfficials = new HashSet<AgendaFirmOfficials>();
        }
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string AgendaTypeId { get; set; }
        public string EventCode { get; set; }
        public string TaskId { get; set; }
        public string ProjectId { get; set; }
        public string FirmOid { get; set; }
        public string TicketOid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CancelDesc { get; set; } 
        public string ComplatedDesc { get; set; }
        public string NoteForCustomer { get; set; }
        public bool IsComplated { get; set; }
        public bool IsCanceled { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public string CancelUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? ComplateDate { get; set; }


        public virtual ICollection<AgendaUsers> Users { get; set; }
        public virtual ICollection<AgendaFixtures> AgendaFixtures { get; set; }
        public virtual ICollection<AgendaFirmOfficials> FirmOfficials { get; set; }

        public virtual AgendaType AgendaType{ get; set; }
    }
}
