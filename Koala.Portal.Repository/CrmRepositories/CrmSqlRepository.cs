using System.Diagnostics;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Providers;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Microsoft.Extensions.Configuration;

namespace Koala.Portal.Repository.CrmRepositories
{
    public class CrmSqlRepository : ICrmSqlRepository
    {
        private readonly ICrmSqlProvider _provider;
        private readonly IConfiguration _configuration;
        private readonly string _crmConnectionString;
        private readonly IUserRepository _userRepository;
        public CrmSqlRepository(ICrmSqlProvider provider, IConfiguration configuration, SistemCrmContext crmContext, IUserRepository userRepository)
        {
            _provider = provider;
            _configuration = configuration;
            _crmConnectionString = _configuration.GetConnectionString("CrmConnection")!;
            _userRepository = userRepository;
        }

        public Response<List<CrmUserDepartmentsViewModel>> GetCrmUserDepartments(string query)
        {
            var res = _provider.SqlReader(_crmConnectionString, query);
            var retVal = new List<CrmUserDepartmentsViewModel>();
            if (!res.IsSuccess)
                return Response<List<CrmUserDepartmentsViewModel>>.FailData(400,
                    "Kullanıcı Departman Listesi Alınırken Bir Sorunla Karşılaşıldı.",
                    "Kullanıcı Departman Listesi Alınırken Bir Sorunla Karşılaşıldı", true);
            for (int i = 0; i < res.Data.Rows.Count; i++)
            {
                retVal.Add(new CrmUserDepartmentsViewModel
                {
                    Oid = res.Data.Rows[i][0].ToString()!,
                    DepartmentName = res.Data.Rows[i][1].ToString()!
                });

            }
            return Response<List<CrmUserDepartmentsViewModel>>.SuccessData(200,
                "Kullanıcı Departman Listesi Başarıyla Alındı", retVal);

        }

        public Response<CrmDashboardKpiDbViewModel> GetCrmDashboardKpi(string query)
        {
            var res = _provider.SqlReader(_crmConnectionString, query);
            var retVal = new CrmDashboardKpiDbViewModel();
            if (!res.IsSuccess)
                return Response<CrmDashboardKpiDbViewModel>.FailData(400,
                    "Kullanıcı Departman Listesi Alınırken Bir Sorunla Karşılaşıldı.",
                    "Kullanıcı Departman Listesi Alınırken Bir Sorunla Karşılaşıldı", true);
            try
            {

                var model = new CrmDashboardKpiDbViewModel
                {
                    WaitingMySupportCount = int.Parse(res.Data.Rows[0]["WaitingMySupportCount"].ToString()!),
                    WaitAnswerSupportCount = int.Parse(res.Data.Rows[0]["WaitAnswerSupportCount"].ToString()!),
                    WaitingdDepartmentSupportCount = int.Parse(res.Data.Rows[0]["WaitingdDepartmentSupportCount"].ToString()!),
                    WaitWebUserSupportCount = int.Parse(res.Data.Rows[0]["WaitWebUserSupportCount"].ToString()!),
                    WaitOnLogoSupportCount = int.Parse(res.Data.Rows[0]["WaitOnLogoSupportCount"].ToString()!),
                };
                retVal = model;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return Response<CrmDashboardKpiDbViewModel>.FailData(400,
                    "Kullanıcı Departman Listesi Alınırken Bir Sorunla Karşılaşıldı.",
                    ex.Message, true);
            }

            //}
            return Response<CrmDashboardKpiDbViewModel>.SuccessData(200,
                "Kullanıcı Departman Listesi Başarıyla Alındı", retVal);
        }

        public Response<string> GetCrmSupportNextId(string query, string updateQuery)
        {
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                return Response<string>.FailData(400,
                    "Destek Kaydı Numarası Alınırken Bir Sorunla Karşılaşıldı.",
                    "Destek Kaydı Numarası Alınırken Bir Sorunla Karşılaşıldı.", true);

            }

            var retVal = $"T-{res.Data.Rows[0][0]}";
            var l = int.Parse(res.Data.Rows[0][0].ToString()!) + 1;
            var o = int.Parse(res.Data.Rows[0][1].ToString()!) + 1;
            updateQuery = updateQuery.Replace("[[LastId]]", $"{l.ToString("D6")}").Replace("[[OptimisticLockField]]", $"{o}");
            _provider.WriteToSql(_crmConnectionString, updateQuery);

            return Response<string>.SuccessData(200,
                "Destek Kaydı Numarası Başarıyla Alındı", retVal);
        }

        public Response<List<CrmUserFullNameInfoViewModel>> GetCrmUserFullNameInfoList(string query)
        {
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                return Response<List<CrmUserFullNameInfoViewModel>>.FailData(400,
                    "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı.",
                    "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı.", true);
            }

            var retVal = new List<CrmUserFullNameInfoViewModel>();

            for (int i = 0; i < res.Data.Rows.Count; i++)
            {
                var rModel = new CrmUserFullNameInfoViewModel
                {
                    Oid = res.Data.Rows[i][0].ToString(),
                    FullName = res.Data.Rows[i][1].ToString()
                };
                retVal.Add(rModel);
            }
            return Response<List<CrmUserFullNameInfoViewModel>>.SuccessData(200, "", retVal);

        }

        public Response<CrmDetailViewModel> GetCrmSupportDetailById(string query)
        {
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                return Response<CrmDetailViewModel>.FailData(400,
                    "Destek Kaydı Bilgisi Alınırken Bir Sorunla Karşılaşıldı.",
                    "Destek Kaydı Bilgisi Alınırken Bir Sorunla Karşılaşıldı.", true);
            }

            if (res.Data.Rows.Count < 1)
            {
                return Response<CrmDetailViewModel>.FailData(404,
                    "Destek Kaydı Bilgisi Alınırken Bir Sorunla Karşılaşıldı.",
                    "Destek Kaydı Bilgisi Alınırken Bir Sorunla Karşılaşıldı. Hata : Bu id bilgisine sahip destek kaydı bulunamadı.", true);
            }
            var retVal = new CrmDetailViewModel
            {
                Oid = res.Data.Rows[0]["ID"].ToString(),
                TicketId = res.Data.Rows[0]["TICKET ID"].ToString(),
                TicketState = res.Data.Rows[0]["DURUM"].ToString(),
                TicketMainCategory = res.Data.Rows[0]["ANA KATEGORİ"].ToString(),
                TicketSubCategory = res.Data.Rows[0]["ALT KATEGORİ"].ToString(),
                TicketType = res.Data.Rows[0]["DESTEK TÜRÜ"].ToString(),
                AssignedDepartment = res.Data.Rows[0]["DEPARTMAN"].ToString(),
                AssignedTo = res.Data.Rows[0]["ATANAN"].ToString(),
                TicketAramaTarihi = res.Data.Rows[0]["ARAMA TARİHİ"].ToString(),
                TicketStartDate = res.Data.Rows[0]["BAŞLAMA TARİHİ"].ToString(),
                ProjectCode = res.Data.Rows[0]["PROJE KODU"].ToString(),
                ProjectLineId = res.Data.Rows[0]["PROJE FAZ ID"].ToString(),
                ProjectLineWorkId = res.Data.Rows[0]["PROJE İŞ ID"].ToString(),
                Notes = res.Data.Rows[0]["MÜŞTERİ TABLEBİ"].ToString(),
                Note = res.Data.Rows[0]["NOT"].ToString(),
                TicketFirm = res.Data.Rows[0]["FİRMA"].ToString(),
                TicketFirmPhone = res.Data.Rows[0]["FİRMA TELEFON"].ToString(),
                TicketContact = res.Data.Rows[0]["YETKİLİ KİŞİ"].ToString(),
                TicketContactPhone = res.Data.Rows[0]["YETKİLİ TELEFON"].ToString(),
                TicketPriority = int.Parse(res.Data.Rows[0]["ÖNCELİK"].ToString() ?? "0"),
                ActiveWorkingUser = res.Data.Rows[0]["ÇALIŞIAN"].ToString(),
                AssignedToOid = res.Data.Rows[0]["ATANAN OID"].ToString(),
                ActiveWorkingUserOid = res.Data.Rows[0]["ÇALIŞAN OID"].ToString(),
                FirmSpecCode5 = res.Data.Rows[0]["ÖZEL KOD5"].ToString()

            };
            retVal.FirmSupportStatus = new FirmSupportStatusViewModel
            {
                LogoSupport = res.Data.Rows[0]["LOGO DESTEK ANLAŞMASI"].ToString() == "True",
                NewLogoSupport = res.Data.Rows[0]["YENİ LOGO DESTEK ANLAŞMASI"].ToString() == "True",
                TecnicalSupport = res.Data.Rows[0]["LOGO TEKNİK DESTEK ANLAŞMASI"].ToString() == "True",
                NewTecnicalSupport = res.Data.Rows[0]["LOGO YENİ DONANIM DESTEK ANLAŞMASI"].ToString() == "True",
                LogoSupportExpDate = res.Data.Rows[0]["LOGO DESTEK ANLAŞMASI BİTİŞ TARİHİ"] != null ? DateTime.Parse(res.Data.Rows[0]["LOGO DESTEK ANLAŞMASI BİTİŞ TARİHİ"].ToString()!) : null,
                NewLogoSupportExpDate = res.Data.Rows[0]["YENİ LOGO DESTEK ANLAŞMASI BİTİŞ TARİHİ"] != null ? DateTime.Parse(res.Data.Rows[0]["YENİ LOGO DESTEK ANLAŞMASI BİTİŞ TARİHİ"].ToString()!) : null,
                TecnicalSupportExpDate = res.Data.Rows[0]["LOGO TEKNİK DESTEK ANLAŞMASI BİTİŞ TARİHİ"] != null ? DateTime.Parse(res.Data.Rows[0]["LOGO TEKNİK DESTEK ANLAŞMASI BİTİŞ TARİHİ"].ToString()!) : null,
                NewTecnicalSupportExpDate = res.Data.Rows[0]["LOGO YENİ DONANIM DESTEK ANLAŞMASI BİTİŞ ANLAŞMASI"] != null ? DateTime.Parse(res.Data.Rows[0]["LOGO YENİ DONANIM DESTEK ANLAŞMASI BİTİŞ ANLAŞMASI"].ToString()!) : null
            };

            return Response<CrmDetailViewModel>.SuccessData(200, "Destek Kaydı Bilgisi Başarıyla Alındı", retVal);
        }

        public async Task<Response<List<CrmDailySupportChartViewModel>>> GetCrmDailyClosedSupportCount(string query1, string query2)
        {
            var retVal = new List<CrmDailySupportChartViewModel>();
            try
            {
                var res1 = _provider.SqlReader(_crmConnectionString, query1);
                if (res1.IsSuccess)
                {
                    var res2 = _provider.SqlReader(_crmConnectionString, query2);
                    if (res2.IsSuccess)
                    {
                        for (int i = 0; i < res1.Data.Rows.Count; i++)
                        {
                            var model = new CrmDailySupportChartViewModel
                            {
                                UserId = res1.Data.Rows[i]["USEROID"].ToString(),
                                Label = res1.Data.Rows[i]["USERNAME"].ToString(),
                                Count = int.Parse(res1.Data.Rows[i]["COUNT"].ToString()),
                                TicketNumbers = res1.Data.Rows[i]["TICKETIDS"].ToString(),
                                Avatar = "",
                                UserSupportDeatils = new List<CrmUserDailySupportInfoViewModel>()
                            };
                            retVal.Add(model);
                        }
                        var avatars = await _userRepository.GetUserAvatarList(retVal.Select(x => x.UserId).ToList());
                        for (int i = 0; i < res2.Data.Rows.Count; i++)
                        {
                            var uOid = res2.Data.Rows[i]["USEROID"].ToString();
                            var line = retVal.FirstOrDefault(x => x.UserId == uOid);
                            line.Avatar = avatars.FirstOrDefault(x => x.Key.Equals(res2.Data.Rows[i]["USEROID"].ToString(), StringComparison.OrdinalIgnoreCase)).Value;
                            if (string.IsNullOrEmpty(line.Avatar))
                            {
                                line.Avatar = "KoalaNoPic.png";
                            }
                            var dModel = new CrmUserDailySupportInfoViewModel
                            {
                                UserId = uOid,
                                Time = res2.Data.Rows[i]["TIME"].ToString(),
                                Firm = res2.Data.Rows[i]["FIRM TITLE"].ToString(),
                                UserFullName = line.Label
                            };
                            line.UserSupportDeatils.Add(dModel);
                        }
                        return Response<List<CrmDailySupportChartViewModel>>.SuccessData(200, "Chart Datası Başarıyla Alındı", retVal);
                    }
                    else
                    {
                        return Response<List<CrmDailySupportChartViewModel>>.FailData(200, "Chart Datası Alınırken Bir Sorunla Karşılaşıldı", "Kullanıcı Detay Verilerine Ulaşılamadı", true);
                    }
                }
                else
                {
                    return Response<List<CrmDailySupportChartViewModel>>.FailData(200, "Chart Datası Alınırken Bir Sorunla Karşılaşıldı", "Destek Kaydı verilerine ulaşılamadı", true);
                }
            }
            catch (Exception ex)
            {
                return Response<List<CrmDailySupportChartViewModel>>.FailData(200, "Chart Datası Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }


        }

        public async Task<Response<List<CrmOpenSupportChartSqlViewModel>>> GetCrmOpenSupportChartData(string query)
        {
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                return Response<List<CrmOpenSupportChartSqlViewModel>>.FailData(400,
                    "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı.",
                    "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı.", true);
            }

            var retVal = new List<CrmOpenSupportChartSqlViewModel>();

            for (int i = 0; i < res.Data.Rows.Count; i++)
            {
                var rModel = new CrmOpenSupportChartSqlViewModel
                {
                    UserId = res.Data.Rows[i]["USEROID"].ToString(),
                    Firm= res.Data.Rows[i]["Firm"].ToString(),
                    TicketNumbers= res.Data.Rows[i]["Ticket"].ToString(),
                    UserName= res.Data.Rows[i]["USERNAME"].ToString(),
                    PassingDay= res.Data.Rows[i]["Beleme Zamanı"].ToString()

                };
                retVal.Add(rModel);
            }
            return Response<List<CrmOpenSupportChartSqlViewModel>>.SuccessData(200, "", retVal);
        }
    }
}
