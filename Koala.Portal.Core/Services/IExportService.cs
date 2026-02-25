using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IExportService
    {
        Task<Response<byte[]>> ExportProjectToPdfAsync(string projectId);
        Task<Response<byte[]>> ExportProjectReportToPdfAsync(string reportType, string? id = null);
        Task<Response<byte[]>> ExportProjectsToExcelAsync(ProjectListFiltersViewModel? filters = null);
        Task<Response<byte[]>> ExportProjectTimelineToPdfAsync(string projectId);
    }
}
