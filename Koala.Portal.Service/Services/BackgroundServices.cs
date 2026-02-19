using AutoMapper;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Services;

namespace Koala.Portal.Service.Services;

public class BackgroundServices : IBackgroundServices
{
    private readonly IFirmService _firmService;
    private readonly ICrmFirmService _crmFirmService;
    private readonly IMapper _mapper;

    public BackgroundServices(IFirmService firmService, ICrmFirmService crmFirmService, IMapper mapper)
    {
        _firmService = firmService;
        _crmFirmService = crmFirmService;
        _mapper = mapper;
    }
    public void SencronFirmJob()
    {

        //Hangfire.RecurringJob.AddOrUpdate("SendDailyReportEmail", () => SendDailyReportEmail(), Cron.Minutely);
        //Hangfire.RecurringJob.AddOrUpdate("SendDailyReportEmail", () => SendDailyReportEmail(), Cron.Weekly(DayOfWeek.Monday,18,0));
        Hangfire.RecurringJob.AddOrUpdate("SencronFirm", () => SencronFirm(), "0 22 * * 1,2,3,4,5");
        //Hangfire.RecurringJob.AddOrUpdate("SendDailyReportEmail", () => SendDailyReportEmail(), "1/1 * * * *");

    }
    public async Task<Response> SencronFirm()
    {
        var currentFirms = await _crmFirmService.GetAllLocalFirm();
        if (!currentFirms.IsSuccess)
        {
            return Response.Fail(currentFirms.StatusCode, currentFirms.Message,
                currentFirms.Errors);

        }
        var fOids = currentFirms.Data;

        var newCrmFirms = _crmFirmService.Where(x => fOids.Select(z=>z.Oid).All(y => y != x.Oid.ToString()));
        if (!newCrmFirms.IsSuccess)
        {
            return Response.Fail(newCrmFirms.StatusCode, newCrmFirms.Message,
                newCrmFirms.Errors);
        }
        try
        {
            var addres = await _firmService.AddRangeAsync(newCrmFirms.Data);
            return Response.Success(200, "Firmalar Başarıyla Senkron Edildi");
        }
        catch (Exception ex)
        {
            return Response.Fail(400, "Firmalar Senkronize Edilirken Bir Sorunla Karşılaşıldı",
                ex.Message, false);
        }
    }
}