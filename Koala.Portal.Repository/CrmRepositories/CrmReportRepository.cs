using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Providers;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Microsoft.Extensions.Configuration;

namespace Koala.Portal.Repository.CrmRepositories;

public class CrmReportRepository : ICrmReportRepository
{
    private readonly ICrmSqlProvider _sqlProvider;
    private readonly string _crmConnection;

    public CrmReportRepository(ICrmSqlProvider sqlProvider, IConfiguration configuration)
    {
        _sqlProvider = sqlProvider;
        _crmConnection = configuration.GetConnectionString("CrmConnection")!;
    }

    public Response<List<TicketReportViewModel>> GetAllTicketData()
    {
        var query = "SELECT * FROM DESTEKKAYDI_PortalReport ORDER BY [BAS TARIHI] DESC";
        var result = _sqlProvider.SqlReader(_crmConnection, query);

        if (!result.IsSuccess || result.Data == null)
            return Response<List<TicketReportViewModel>>.FailData(500, "Veriler alınamadı", result.Message, true);

        var data = new List<TicketReportViewModel>();
        foreach (System.Data.DataRow row in result.Data.Rows)
        {
            data.Add(new TicketReportViewModel
            {
                Oid = row["OID"]?.ToString() ?? "",
                TicketId = row["DESTEK ID"]?.ToString() ?? "",
                TicketDescription = row["DESTEK ACIKLAMA"]?.ToString() ?? "",
                MainCategory = row["ANA KATEGORI"]?.ToString() ?? "",
                SubCategory = row["ALT KATEGORI"]?.ToString() ?? "",
                Type = row["TUR"]?.ToString() ?? "",
                FirmCode = row["FIRMA KOD"]?.ToString() ?? "",
                FirmName = row["FIRMA UNVAN"]?.ToString() ?? "",
                FirmOid = row["FIRM OID"]?.ToString() ?? "",
                ContactName = row["KISI"]?.ToString() ?? "",
                AssignedTo = row["ATANAN"]?.ToString() ?? "",
                AssignedToOid = row["KISI OID"]?.ToString() ?? "",
                Priority = row["ONCELIK"] != DBNull.Value ? Convert.ToInt32(row["ONCELIK"]) : 0,
                CallDate = row["ARAMA TARIHI"] != DBNull.Value ? Convert.ToDateTime(row["ARAMA TARIHI"]) : null,
                StartDate = row["BAS TARIHI"] != DBNull.Value ? Convert.ToDateTime(row["BAS TARIHI"]) : null,
                CompleteDate = row["TMM TARIHI"] != DBNull.Value ? Convert.ToDateTime(row["TMM TARIHI"]) : null,
                Year = row["YIL"] != DBNull.Value ? Convert.ToInt32(row["YIL"]) : DateTime.Today.Year,
                Month = row["AY"] != DBNull.Value ? Convert.ToInt32(row["AY"]) : DateTime.Today.Month,
                Department = row["DEPARTMAN"]?.ToString() ?? "",
                ActiveUser = row["ÇALIŞAN KULLANICI"]?.ToString() ?? "",
                ActiveUserOid = row["ÇALIŞAN KULLANICI OID"]?.ToString() ?? "",
                Status = row["DURUM"]?.ToString() ?? "",
                StatusOid = row["DURUM OID"]?.ToString() ?? "",
                IsCompleted = row["TAMAMLANDI"] != DBNull.Value && Convert.ToBoolean(row["TAMAMLANDI"]),
                CustomerRequest = row["MUSTERI TALEBI"]?.ToString() ?? "",
                WorkDone = row["YAPILAN ISLEM"]?.ToString() ?? "",
                Price = row["UCRET"]?.ToString() ?? "",
                IsContinuing = row["DEVAM EDIYOR"] != DBNull.Value && Convert.ToBoolean(row["DEVAM EDIYOR"])
            });
        }

        return Response<List<TicketReportViewModel>>.SuccessData(200, "Veriler alındı", data);
    }
}
