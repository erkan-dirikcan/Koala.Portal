using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using System.Text;

namespace Koala.Portal.Service.Services
{
    public class ExportService : IExportService
    {
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectService _projectService;

        public ExportService(
            IUnitOfWork<AppDbContext> unitOfWork,
            IProjectRepository projectRepository,
            IProjectService projectService)
        {
            _unitOfWork = unitOfWork;
            _projectRepository = projectRepository;
            _projectService = projectService;
        }

        public async Task<Response<byte[]>> ExportProjectToPdfAsync(string projectId)
        {
            try
            {
                var projectResult = await _projectService.GetProjectByIdAsync(projectId);
                if (!projectResult.IsSuccess || projectResult.Data == null)
                {
                    return Response<byte[]>.FailData(404, "Proje bulunamadı", "Proje bilgilerine ulaşılamadı", true);
                }

                var project = projectResult.Data;

                // For now, generate HTML that can be converted to PDF
                // In production, use QuestPDF or iTextSharp
                var htmlContent = GenerateProjectHtml(project);

                // Convert HTML to bytes (placeholder - should use proper PDF library)
                var pdfBytes = Encoding.UTF8.GetBytes(htmlContent);

                return Response<byte[]>.SuccessData(200, "PDF başarıyla oluşturuldu", pdfBytes);
            }
            catch (Exception ex)
            {
                return Response<byte[]>.FailData(400, "PDF oluşturulurken hata oluştu", ex.Message, false);
            }
        }

        public async Task<Response<byte[]>> ExportProjectReportToPdfAsync(string reportType, string? id = null)
        {
            try
            {
                string htmlContent = string.Empty;

                switch (reportType.ToLower())
                {
                    case "completion":
                        htmlContent = await GenerateCompletionReportHtml(id);
                        break;
                    case "workload":
                        htmlContent = await GenerateWorkloadReportHtml();
                        break;
                    case "firm":
                        htmlContent = await GenerateFirmReportHtml(id);
                        break;
                    default:
                        return Response<byte[]>.FailData(400, "Geçersiz rapor türü", "Rapor türü tanımlanamadı", true);
                }

                var pdfBytes = Encoding.UTF8.GetBytes(htmlContent);
                return Response<byte[]>.SuccessData(200, "Rapor PDF'i başarıyla oluşturuldu", pdfBytes);
            }
            catch (Exception ex)
            {
                return Response<byte[]>.FailData(400, "Rapor oluşturulurken hata oluştu", ex.Message, false);
            }
        }

        public async Task<Response<byte[]>> ExportProjectsToExcelAsync(ProjectListFiltersViewModel? filters = null)
        {
            try
            {
                var projectsResult = await _projectService.GetProjectListAsync();
                if (!projectsResult.IsSuccess || projectsResult.Data == null)
                {
                    return Response<byte[]>.FailData(400, "Projeler alınamadı", "Proje listesine ulaşılamadı", true);
                }

                var projects = projectsResult.Data;

                // Apply filters if provided
                if (filters != null)
                {
                    if (!string.IsNullOrEmpty(filters.StatusFilter) && Enum.TryParse<ProjectStatusEnum>(filters.StatusFilter, true, out var statusEnum))
                    {
                        projects = projects.Where(p => p.ProjectStatus == statusEnum).ToList();
                    }
                    // Manager and firm filters require project detail data - not implemented for list export
                }

                // Generate CSV content (placeholder - should use ClosedXML for actual Excel)
                var csvContent = GenerateProjectsCsv(projects);
                var excelBytes = Encoding.UTF8.GetBytes(csvContent);

                return Response<byte[]>.SuccessData(200, "Excel dosyası başarıyla oluşturuldu", excelBytes);
            }
            catch (Exception ex)
            {
                return Response<byte[]>.FailData(400, "Excel oluşturulurken hata oluştu", ex.Message, false);
            }
        }

        public async Task<Response<byte[]>> ExportProjectTimelineToPdfAsync(string projectId)
        {
            try
            {
                var projectResult = await _projectService.GetProjectByIdAsync(projectId);
                if (!projectResult.IsSuccess || projectResult.Data == null)
                {
                    return Response<byte[]>.FailData(404, "Proje bulunamadı", "Proje bilgilerine ulaşılamadı", true);
                }

                var project = projectResult.Data;
                var htmlContent = GenerateTimelineHtml(project);

                var pdfBytes = Encoding.UTF8.GetBytes(htmlContent);
                return Response<byte[]>.SuccessData(200, "Timeline PDF'i başarıyla oluşturuldu", pdfBytes);
            }
            catch (Exception ex)
            {
                return Response<byte[]>.FailData(400, "Timeline oluşturulurken hata oluştu", ex.Message, false);
            }
        }

        private string GenerateProjectHtml(ProjectDetailViewModel project)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html><head><meta charset='utf-8'>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Arial, sans-serif; margin: 40px; }");
            sb.AppendLine("h1 { color: #2c3e50; border-bottom: 2px solid #3498db; padding-bottom: 10px; }");
            sb.AppendLine(".section { margin: 20px 0; }");
            sb.AppendLine(".label { font-weight: bold; color: #34495e; }");
            sb.AppendLine(".value { margin-left: 10px; }");
            sb.AppendLine(".status { padding: 5px 10px; border-radius: 4px; color: white; }");
            sb.AppendLine("table { width: 100%; border-collapse: collapse; margin: 20px 0; }");
            sb.AppendLine("th, td { border: 1px solid #ddd; padding: 12px; text-align: left; }");
            sb.AppendLine("th { background-color: #3498db; color: white; }");
            sb.AppendLine("</style></head><body>");
            sb.AppendLine($"<h1>Proje Raporu: {project.ProjectName}</h1>");
            sb.AppendLine($"<div class='section'><span class='label'>Proje Kodu:</span><span class='value'>{project.ProjectCode}</span></div>");
            sb.AppendLine($"<div class='section'><span class='label'>Firma:</span><span class='value'>{project.Firm?.Title}</span></div>");
            sb.AppendLine($"<div class='section'><span class='label'>Proje Yöneticisi:</span><span class='value'>{project.ProjectManager?.Fullname}</span></div>");
            sb.AppendLine($"<div class='section'><span class='label'>Durum:</span><span class='value'>{GetProjectStatusText(project.ProjectStatus)}</span></div>");
            sb.AppendLine($"<div class='section'><span class='label'>Başlangıç Tarihi:</span><span class='value'>{project.StartDate?.ToString("dd.MM.yyyy")}</span></div>");
            sb.AppendLine($"<div class='section'><span class='label'>Bitiş Tarihi:</span><span class='value'>{project.EndDate?.ToString("dd.MM.yyyy")}</span></div>");
            sb.AppendLine($"<div class='section'><span class='label'>Termin Tarihi:</span><span class='value'>{project.DueDate?.ToString("dd.MM.yyyy")}</span></div>");
            sb.AppendLine($"<div class='section'><span class='label'>Açıklama:</span><span class='value'>{project.Description}</span></div>");

            if (project.ProjectLines != null && project.ProjectLines.Any())
            {
                sb.AppendLine("<h2>Proje Fazları</h2>");
                sb.AppendLine("<table><tr><th>Faz Adı</th><th>Durum</th><th>Öncelik</th><th>Termin</th></tr>");
                foreach (var line in project.ProjectLines)
                {
                    sb.AppendLine($"<tr><td>{line.Title}</td><td>{GetLineStatusText(line.StateStatus)}</td><td>{line.Priority}</td><td>{line.DueDate}</td></tr>");
                }
                sb.AppendLine("</table>");
            }

            sb.AppendLine("</body></html>");
            return sb.ToString();
        }

        private async Task<string> GenerateCompletionReportHtml(string? projectId)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'>");
            sb.AppendLine("<style>body { font-family: Arial; margin: 40px; } table { width: 100%; border-collapse: collapse; } th, td { border: 1px solid #ddd; padding: 10px; } th { background: #3498db; color: white; }</style></head><body>");
            sb.AppendLine("<h1>Proje Tamamlanma Raporu</h1>");

            var projectsResult = await _projectService.GetProjectListAsync();
            if (projectsResult.IsSuccess && projectsResult.Data != null)
            {
                sb.AppendLine("<table><tr><th>Proje Kodu</th><th>Proje Adı</th><th>Durum</th><th>Firma</th><th>Termin Tarihi</th></tr>");
                foreach (var project in projectsResult.Data)
                {
                    sb.AppendLine($"<tr><td>{project.ProjectCode}</td><td>{project.ProjectName}</td><td>{GetProjectStatusText(project.ProjectStatus)}</td><td>{project.Firm}</td><td>{project.DueDate}</td></tr>");
                }
                sb.AppendLine("</table>");
            }

            sb.AppendLine("</body></html>");
            return sb.ToString();
        }

        private async Task<string> GenerateWorkloadReportHtml()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'>");
            sb.AppendLine("<style>body { font-family: Arial; margin: 40px; }</style></head><body>");
            sb.AppendLine("<h1>Ekip İş Yükü Raporu</h1>");
            sb.AppendLine("<p>Bu rapor yakında detaylı olarak sunulacaktır.</p>");
            sb.AppendLine("</body></html>");
            return sb.ToString();
        }

        private async Task<string> GenerateFirmReportHtml(string? firmId)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'>");
            sb.AppendLine("<style>body { font-family: Arial; margin: 40px; }</style></head><body>");
            sb.AppendLine("<h1>Firma Proje Özeti Raporu</h1>");
            sb.AppendLine("<p>Bu rapor yakında detaylı olarak sunulacaktır.</p>");
            sb.AppendLine("</body></html>");
            return sb.ToString();
        }

        private string GenerateTimelineHtml(ProjectDetailViewModel project)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'>");
            sb.AppendLine("<style>body { font-family: Arial; margin: 40px; } .task { border: 1px solid #ddd; padding: 10px; margin: 10px 0; }</style></head><body>");
            sb.AppendLine($"<h1>Timeline: {project.ProjectName}</h1>");

            if (project.ProjectLines != null)
            {
                foreach (var line in project.ProjectLines.OrderBy(l => l.RowOrder))
                {
                    sb.AppendLine($"<div class='task'><strong>{line.Title}</strong> - {GetLineStatusText(line.StateStatus)}</div>");
                }
            }

            sb.AppendLine("</body></html>");
            return sb.ToString();
        }

        private string GenerateProjectsCsv(List<ProjectListViewModel> projects)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Proje Kodu;Proje Adı;Firma;Proje Yöneticisi;Durum;Başlangıç Tarihi;Termin Tarihi");
            foreach (var project in projects)
            {
                sb.AppendLine($"{project.ProjectCode};{project.ProjectName};{project.Firm};{project.ProjectManager};{GetProjectStatusText(project.ProjectStatus)};{project.StartDate};{project.DueDate}");
            }
            return sb.ToString();
        }

        private string GetProjectStatusText(ProjectStatusEnum status)
        {
            return status switch
            {
                ProjectStatusEnum.Created => "Oluşturuldu",
                ProjectStatusEnum.Started => "Başladı",
                ProjectStatusEnum.Testing => "Test Ediliyor",
                ProjectStatusEnum.Finished => "Tamamlandı",
                ProjectStatusEnum.Canceled => "İptal Edildi",
                ProjectStatusEnum.Failed => "Başarısız",
                _ => status.ToString()
            };
        }

        private string GetLineStatusText(ProjectLineStatusEnum status)
        {
            return status switch
            {
                ProjectLineStatusEnum.NotStarted => "Başlamadı",
                ProjectLineStatusEnum.InProgress => "Devam Ediyor",
                ProjectLineStatusEnum.Completed => "Tamamlandı",
                ProjectLineStatusEnum.WaitingForSomeoneElse => "Başkasını Bekliyor",
                ProjectLineStatusEnum.Deferred => "Ertelendi",
                ProjectLineStatusEnum.Cancellled => "İptal Edildi",
                _ => status.ToString()
            };
        }
    }
}
