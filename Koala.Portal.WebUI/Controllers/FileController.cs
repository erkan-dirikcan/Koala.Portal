using Koala.Portal.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        private readonly ISupportFileService _supportFileService;

        public FileController(ISupportFileService supportFileService)
        {
            _supportFileService = supportFileService;
        }

        public async Task<FileResult> GetSupportFile(string fileId)
        {
            var fInfo = await _supportFileService.GetByIdAsyc(fileId);
            return File(fInfo.Data.UrlSlug, fInfo.Data.Endwith);
        }
       
    }
}
