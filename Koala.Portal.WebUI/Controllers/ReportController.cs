using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.WebUI.Controllers;

[Authorize]
public class ReportController : Controller
{
    private readonly ICrmReportService _reportService;
    private readonly ICrmSelectListService _crmSelectListService;

    public ReportController(ICrmReportService reportService, ICrmSelectListService crmSelectListService)
    {
        _reportService = reportService;
        _crmSelectListService = crmSelectListService;
    }

    [HttpGet]
    public async Task<IActionResult> TicketReport()
    {
        // SelectList'leri doldur
        var firmsTask = _crmSelectListService.GetFirmSelectList("");
        var personsTask = _crmSelectListService.GetUserSelectList(true, "");
        var statesTask = _crmSelectListService.GetSupportStateSelectList(new List<string>());

        await Task.WhenAll(firmsTask, personsTask, statesTask);

        ViewData["Firms"] = firmsTask.Result.Data ?? new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        ViewData["Persons"] = personsTask.Result.Data ?? new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        ViewData["States"] = statesTask.Result.Data ?? new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

        // Verileri getir
        var result = _reportService.GetAllTicketData();

        if (!result.IsSuccess)
        {
            TempData["Error"] = result.Message;
            return View(new List<TicketReportViewModel>());
        }

        return View(result.Data);
    }

    [HttpPost]
    public IActionResult ExportPersonnelExcel([FromBody] PersonnelExportRequest request)
    {
        var allData = _reportService.GetAllTicketData();
        if (!allData.IsSuccess)
        {
            return BadRequest(allData.Message);
        }

        // Filtrele - sadece seçilen personelin verilerini al
        var filteredData = allData.Data
            .Where(d => d.ActiveUser == request.PersonName)
            .ToList();

        return GenerateExcel(filteredData, "Personel_Detay");
    }

    [HttpPost]
    public IActionResult ExportTicketReportExcel([FromBody] TicketExportRequest request)
    {
        var allData = _reportService.GetAllTicketData();
        if (!allData.IsSuccess)
        {
            return BadRequest(allData.Message);
        }

        var filteredData = allData.Data.AsEnumerable();

        // Tarih filtre
        if (request.StartDate.HasValue)
        {
            filteredData = filteredData.Where(d => d.StartDate >= request.StartDate.Value);
        }
        if (request.EndDate.HasValue)
        {
            var endDate = request.EndDate.Value.Date.AddDays(1).AddTicks(-1);
            filteredData = filteredData.Where(d => d.StartDate <= endDate);
        }

        // Firma filtre
        if (request.Firms?.Any() == true)
        {
            filteredData = filteredData.Where(d => request.Firms.Contains(d.FirmName));
        }

        // Personel filtre
        if (request.Persons?.Any() == true)
        {
            filteredData = filteredData.Where(d => request.Persons.Contains(d.ActiveUser));
        }

        // Durum filtre
        if (request.Statuses?.Any() == true)
        {
            filteredData = filteredData.Where(d => request.Statuses.Contains(d.Status));
        }

        return GenerateExcel(filteredData.ToList(), "Ticket_Rapor");
    }

    private FileContentResult GenerateExcel(List<TicketReportViewModel> data, string baseFileName)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Rapor");

            // Header
            worksheet.Cell("A1").Value = "Destek Numarası";
            worksheet.Cell("B1").Value = "Firma Kodu";
            worksheet.Cell("C1").Value = "Yetkili";
            worksheet.Cell("D1").Value = "Departman";
            worksheet.Cell("E1").Value = "Atanan";
            worksheet.Cell("F1").Value = "Aktif Kullanıcı";
            worksheet.Cell("G1").Value = "Arama Zamanı";
            worksheet.Cell("H1").Value = "Firma Adı";
            worksheet.Cell("I1").Value = "Müşteri Talebi";
            worksheet.Cell("J1").Value = "Kategori";
            worksheet.Cell("K1").Value = "Alt Kategori";
            worksheet.Cell("L1").Value = "Destek Türü";
            worksheet.Cell("M1").Value = "Durum";
            worksheet.Cell("N1").Value = "Başlama Zamanı";
            worksheet.Cell("O1").Value = "Bitiş Zamanı";
            worksheet.Cell("P1").Value = "Öncelik";
            worksheet.Cell("Q1").Value = "Tamamlandı";
            worksheet.Cell("R1").Value = "Devam Ediyor";
            worksheet.Cell("S1").Value = "Alınan Ücret";

            // Header style
            var headerRange = worksheet.Range(1, 1, 1, 19);
            headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#6993FF");
            headerRange.Style.Font.FontColor = XLColor.White;
            headerRange.Style.Font.Bold = true;

            // Data
            int row = 2;
            foreach (var item in data)
            {
                worksheet.Cell(row, 1).Value = item.TicketId ?? "";
                worksheet.Cell(row, 2).Value = item.FirmCode ?? "";
                worksheet.Cell(row, 3).Value = item.ContactName ?? "";
                worksheet.Cell(row, 4).Value = item.Department ?? "";
                worksheet.Cell(row, 5).Value = item.AssignedTo ?? "";
                worksheet.Cell(row, 6).Value = item.ActiveUser ?? "";
                worksheet.Cell(row, 7).Value = item.CallDate?.ToString("dd.MM.yyyy HH:mm") ?? "";
                worksheet.Cell(row, 8).Value = item.FirmName ?? "";
                worksheet.Cell(row, 9).Value = item.CustomerRequest ?? "";
                worksheet.Cell(row, 10).Value = item.MainCategory ?? "";
                worksheet.Cell(row, 11).Value = item.SubCategory ?? "";
                worksheet.Cell(row, 12).Value = item.Type ?? "";
                worksheet.Cell(row, 13).Value = item.Status ?? "";
                worksheet.Cell(row, 14).Value = item.StartDate?.ToString("dd.MM.yyyy HH:mm") ?? "";
                worksheet.Cell(row, 15).Value = item.CompleteDate?.ToString("dd.MM.yyyy HH:mm") ?? "";
                worksheet.Cell(row, 16).Value = item.Priority.ToString();
                worksheet.Cell(row, 17).Value = item.IsCompleted ? "Evet" : "Hayır";
                worksheet.Cell(row, 18).Value = item.IsContinuing ? "Evet" : "Hayır";
                worksheet.Cell(row, 19).Value = item.Price ?? "";
                row++;
            }

            // Auto fit columns
            worksheet.Columns().AdjustToContents();

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return File(
                    stream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"{baseFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                );
            }
        }
    }
}

public class PersonnelExportRequest
{
    public string PersonName { get; set; }
}

public class TicketExportRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<string> Firms { get; set; }
    public List<string> Persons { get; set; }
    public List<string> Statuses { get; set; }
}
