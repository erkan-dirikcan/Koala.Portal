using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebApi.Controllers
{
    /// <summary>
    /// 3CX Santral Crm Haberleşme Metotları
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Policy = "3CX")]
    public class App3CxController : ControllerBase
    {
        private readonly ICrmFirmService _firmService;
       

        public App3CxController(ICrmFirmService firmService, ICrmPhoneService phoneService)
        {
            _firmService = firmService;
        }
        /// <summary>
        /// Müşteri Bilgilerine Telefon Numarasını Telefon Numarası Kullanarak Bulmak İçin Kullanılır.
        /// </summary>
        /// <param name="model">Arama Yapılacak Model</param>
        /// <returns></returns>
        [HttpGet]
        public Response<Firm3cxInfoViewModel> FindCustonerWithPhone(string phone, string callDirection)
        {
            /*
             *The call direction during contact lookup, it can be “Inbound” or “Outbound”.
             *
             */
            if (callDirection=="Outbound")
            {
                return Response<Firm3cxInfoViewModel>.FailData(400, "Giden Aramalar karşılaştırılmaz", "Outbound Call", false);
            }

            var firm = _firmService.GetFirmInfoWithPhone(new GetFirm3cxInfoByPhoneViewModel{CallDirection = callDirection,Phone = phone});
            return !firm.IsSuccess ? 
                Response<Firm3cxInfoViewModel>.FailData(firm.StatusCode, firm.Message, firm.Errors.Errors, false) : 
                Response<Firm3cxInfoViewModel>.SuccessData(200, "Arayan kimliği başarıyla alındı",firm.Data);
        }
    }
}
