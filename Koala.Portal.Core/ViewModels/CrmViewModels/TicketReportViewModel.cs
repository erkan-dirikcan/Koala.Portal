using System.ComponentModel.DataAnnotations;

namespace Koala.Portal.Core.ViewModels.CrmViewModels;

public class TicketReportViewModel
{
    public string Oid { get; set; }
    public string TicketId { get; set; }
    public string TicketDescription { get; set; }
    public string MainCategory { get; set; }
    public string SubCategory { get; set; }
    public string Type { get; set; }
    public string FirmCode { get; set; }
    public string FirmName { get; set; }
    public string FirmOid { get; set; }
    public string ContactName { get; set; }
    public string AssignedTo { get; set; }
    public string AssignedToOid { get; set; }
    public int Priority { get; set; }
    public DateTime? CallDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompleteDate { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public string Department { get; set; }
    public string ActiveUser { get; set; }
    public string ActiveUserOid { get; set; }
    public string Status { get; set; }
    public string StatusOid { get; set; }
    public bool IsCompleted { get; set; }
    public string CustomerRequest { get; set; }
    public string WorkDone { get; set; }
    public string Price { get; set; }
    public bool IsContinuing { get; set; }

    // Hesaplanmış alanlar
    public int DurationDays => StartDate.HasValue && CompleteDate.HasValue
        ? (CompleteDate.Value - StartDate.Value).Days
        : StartDate.HasValue
            ? (DateTime.Today - StartDate.Value).Days
            : 0;
}
