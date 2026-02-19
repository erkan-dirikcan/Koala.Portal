using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Providers;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Microsoft.Extensions.Configuration;

namespace Koala.Portal.Service.CrmServices
{
    public class CrmSqlService : ICrmSqlService
    {
        private readonly ICrmSqlRepository _crmRepository;
        private readonly ICrmSqlProvider _sqlProvider;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public CrmSqlService(ICrmSqlRepository crmRepository, ICrmSqlProvider sqlProvider, IConfiguration configuration, IUserRepository userRepository)
        {
            _crmRepository = crmRepository;
            _sqlProvider = sqlProvider;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public Response<List<CrmUserDepartmentsViewModel>> GetCrmUserDepartments(string userOid)
        {
            var query = @$"SELECT DP.Oid, DP.DepartmentName FROM ST_User AS US INNER JOIN 
                           RL_Users_Departments AS UD ON UD.UserOid=US.Oid INNER JOIN
                           CT_User_Departments AS DP ON DP.Oid=UD.DepartmentOid
                           WHERE US.Oid='{userOid}' AND DP.GCRecord IS NULL";

            return _crmRepository.GetCrmUserDepartments(query);
        }
        public Response<string> GetCrmSupportNextId()
        {
            const string query = @$"select LastId,OptimisticLockField from SS_Generated_Ids where Oid='663DB3D4-BFC6-45D1-B224-44011F3E0790'";
            const string updateQuery = @$"update SS_Generated_Ids set LastId=[[LastId]],OptimisticLockField=[[OptimisticLockField]] where Oid='663DB3D4-BFC6-45D1-B224-44011F3E0790'";

            return _crmRepository.GetCrmSupportNextId(query, updateQuery);
        }

        public Response<List<CrmUserFullNameInfoViewModel>> GetCrmUserFullNameInfoList()
        {
            const string query = "select Oid,Caption from ST_User";
            return _crmRepository.GetCrmUserFullNameInfoList(query);
        }

        public Response<CrmDetailViewModel> GetCrmSupportDetailById(string supportId)
        {
            var query = $@"SELECT
                         A.Oid AS 'ID',
                         A.TicketId AS 'TICKET ID',
                         B.Oid AS 'FİRMA OID',
                         B.FirmTitle AS 'FİRMA',
                         C.Oid AS 'YETKİLİ OID',
                         C.FullName AS 'YETKİLİ KİŞİ',
                         A.DevamEdiyor AS 'DEVAM',
                         ISNULL(B.FirmLogoBakimAnlasmasi,0 ) AS 'LOGO DESTEK ANLAŞMASI',
                         ISNULL(B.FirmLogoBakimBitisTarihi,'' )  AS 'LOGO DESTEK ANLAŞMASI BİTİŞ TARİHİ',
                         ISNULL(B.FirmYeniLogoBakimAnlasmasi,0 )  AS 'YENİ LOGO DESTEK ANLAŞMASI',
                         ISNULL(B.FirmYeniLogoBakimBitisTarihi,'' )  AS 'YENİ LOGO DESTEK ANLAŞMASI BİTİŞ TARİHİ',
                         ISNULL(B.FirmTeknikBakimAnlasmasi,0 )  AS 'LOGO TEKNİK DESTEK ANLAŞMASI',
                         ISNULL(B.FirmTeknikBakimBitisTarihi,'' )  AS 'LOGO TEKNİK DESTEK ANLAŞMASI BİTİŞ TARİHİ',
                         ISNULL(B.FirmYeniDonanimBakimAnlasmasi,0 )  AS 'LOGO YENİ DONANIM DESTEK ANLAŞMASI',
                         ISNULL(B.FirmYeniDonanimBakimBitisTarihi,'' )  AS 'LOGO YENİ DONANIM DESTEK ANLAŞMASI BİTİŞ ANLAŞMASI',
                         ISNULL(A.NOTES, '-') AS 'MÜŞTERİ TABLEBİ',
                         ISNULL(A.NOTLAR, '-') AS 'NOT',
                         ISNULL(D.Caption,'-') AS 'ATANAN',
                         D.Oid AS 'ATANAN OID',
                         ISNULL(K.Caption,'-') AS 'ÇALIŞIAN',
                         K.Oid AS 'ÇALIŞAN OID',
                         ISNULL(F.DepartmentName,'-') AS 'DEPARTMAN',
                         A.AssignedDepartment AS 'DEPARTMAN OID',
                         A.Priority AS 'ÖNCELİK',
                         ISNULL(A.TicketYapilanIslem, '-') AS 'YAPILAN İŞLEM',
                         ISNULL(A.TicketAramaTarihi, '') AS 'ARAMA TARİHİ',
                         ISNULL(A.TicketStartDate, '') AS 'BAŞLAMA TARİHİ',
                         ISNULL(A.TicketCompletedDate, '') AS 'BİTİŞ TARİHİ',
                         ISNULL(A.TicketEstEndDate, '') AS 'TAMAMLANMASI GEREKEN TARİH',
                         ISNULL(G.TicketMainCategoryDescription, '-') AS 'ANA KATEGORİ',
                         ISNULL(H.TicketSubCategoryDescription, '-') AS 'ALT KATEGORİ',
                         ISNULL(I.TicketTypeDescription, '-') AS 'DESTEK TÜRÜ',
                         ISNULL(J.TicketStateDescription,'-') AS 'DURUM',
                         ISNULL(A.ProjectCode,'-') as 'PROJE KODU',
                         ISNULL(A.ProjectLineId,'-') as 'PROJE FAZ ID',
                         ISNULL(A.ProjectLineWorkId,'-') as 'PROJE İŞ ID',
                         ISNULL((SELECT STRING_AGG(CONVERT(NVARCHAR(max),('('+FP.AreaCode+') - '+FP.NUMBER)), ';') FROM PO_Phone_Number AS FP  WHERE FP.RelatedContact IS NULL AND B.Oid=FP.RelatedFirm),'-') AS 'FİRMA TELEFON',
                         ISNULL((SELECT STRING_AGG(CONVERT(NVARCHAR(max),('('+FP.AreaCode+') - '+FP.NUMBER)), ';') FROM PO_Phone_Number AS FP  WHERE FP.RelatedContact = D.Oid),'-') AS 'YETKİLİ TELEFON',
                         ISNULL(B.Auxiliary_Code5,'') AS 'ÖZEL KOD5'
                        FROM
                         [SistemCrm].[dbo].[MT_Ticket] AS A
                         LEFT join MT_Firm AS B on a.TicketFirm = b.Oid
                         LEFT join MT_Contact AS C on A.TicketContact = C.Oid
                         left outer join ST_User AS D ON D.Oid = A.AssignedTo
                         left outer join ST_User AS K ON K.Oid = A.ActiveWorkingUser
                         left outer join RL_Users_Departments AS E on E.DepartmentOid = A.AssignedDepartment
                         and E.UserOid = A.AssignedTo
                         left outer join CT_User_Departments AS F ON F.Oid = E.DepartmentOid
                         LEFT JOIN CT_Ticket_Main_Category AS G ON G.Oid = A.TicketMainCategory
                         LEFT JOIN CT_Ticket_Sub_Category AS H ON H.Oid = A.TicketSubCategory
                         LEFT JOIN CT_Ticket_Types AS I ON I.Oid = A.TicketType
                         LEFT OUTER JOIN CT_Ticket_States AS J on A.TicketState = J.Oid
                        where
                         A.GCRecord IS NULL
                         AND A.Oid = '{supportId}' 
                         GROUP BY A.Oid,
                         A.TicketId,
                         B.Oid,
                         B.FirmTitle,
                         C.Oid ,
                         C.FullName,
                         A.DevamEdiyor,
                         B.FirmLogoBakimAnlasmasi,
                         B.FirmLogoBakimBitisTarihi,
                         B.FirmYeniLogoBakimAnlasmasi,
                         B.FirmYeniLogoBakimBitisTarihi,
                         B.FirmTeknikBakimAnlasmasi,
                         B.FirmTeknikBakimBitisTarihi,
                         B.FirmYeniDonanimBakimAnlasmasi,
                         B.FirmYeniDonanimBakimBitisTarihi,
                         A.NOTES,
                         A.NOTLAR,
                         D.Caption,
                         D.Oid,
                         K.Caption,
                         K.Oid,
                         F.DepartmentName,
                         A.AssignedDepartment,
                         A.Priority,
                         A.TicketYapilanIslem,
                         A.TicketAramaTarihi,
                         A.TicketStartDate,
                         A.TicketCompletedDate,
                         A.TicketEstEndDate,
                         G.TicketMainCategoryDescription,
                         H.TicketSubCategoryDescription,
                         I.TicketTypeDescription, 
                         J.TicketStateDescription,
                         A.ProjectCode,
                         A.ProjectLineId,
                         A.ProjectLineWorkId,
                         B.Auxiliary_Code5";
            try
            {
                var res = _crmRepository.GetCrmSupportDetailById(query);
                return res;
            }
            catch (Exception ex)
            {
                return Response<CrmDetailViewModel>.FailData(400, "Destek Kaydı Bilgisi Alınırken Bir Sorunbla Karşılaşıldı", ex.Message, false);
            }

        }
        public Response<CrmDashboardKpiDbViewModel> GetCrmDashboardKpi(string userOid)
        {
            var date = DateTime.Now.AddDays(-7);
            var query = @$"SELECT distinct (SELECT COUNT(1)
					FROM MT_Ticket AS A INNER JOIN
					ST_User AS D ON D.Oid = A.AssignedTo LEFT OUTER JOIN
					CT_Ticket_States AS J ON A.TicketState=J.Oid
					WHERE (A.ActiveWorkingUser='{userOid}' or A.ActiveWorkingUser='{userOid}') and
					A.TicketAramaTarihi > '2021' AND A.GCRecord IS NULL AND J.TicketStateDescription NOT IN('Ücretli Kapandı','Tamamlandı','Logoda Bekliyor') ) AS [WaitingMySupportCount]
			  ,(SELECT COUNT(1)
			       FROM MT_Ticket AS A INNER JOIN  
			       ST_User AS D ON D.Oid = A.AssignedTo LEFT OUTER JOIN 
			       CT_Ticket_States AS J on A.TicketState=J.Oid
			       WHERE A._CreatedDateTime > '2021' AND A.GCRecord IS NULL AND J.TicketStateDescription NOT IN('Ücretli Kapandı','Tamamlandı','Logoda Bekliyor') 
			       AND A.AssignedTo='F2028B99-C49E-4F4B-B1E7-69FF7ACF869A'  AND A.ActiveWorkingUser IS NULL) AS [WaitAnswerSupportCount]
			 ,(SELECT COUNT(1)
			      FROM MT_Ticket AS A INNER JOIN
			      ST_User AS D ON D.Oid = A.AssignedTo LEFT OUTER JOIN
			      CT_Ticket_States AS J ON A.TicketState=J.Oid
			      WHERE A.AssignedDepartment IN (SELECT DepartmentOid FROM RL_Users_Departments WHERE UserOid='{userOid}') 
			 	  AND A.TicketAramaTarihi > '2021' AND A.GCRecord IS NULL AND J.TicketStateDescription NOT IN('Ücretli Kapandı','Tamamlandı','Logoda Bekliyor') ) AS [WaitingdDepartmentSupportCount]
			 ,(SELECT COUNT(1)
			     FROM MT_Ticket AS A INNER JOIN  
			     ST_User AS D ON D.Oid = A.AssignedTo LEFT OUTER JOIN 
			     CT_Ticket_States AS J on A.TicketState=J.Oid
			     WHERE A._CreatedDateTime > '2021' AND A.GCRecord IS NULL AND J.TicketStateDescription NOT IN('Ücretli Kapandı','Tamamlandı','Logoda Bekliyor') 
			     AND A.AssignedTo='A0EFF398-D31A-4767-A1DE-445312C9E086'  AND A.ActiveWorkingUser IS NULL ) AS [WaitWebUserSupportCount]
			,(SELECT COUNT(1)
			     FROM MT_Ticket AS A INNER JOIN
			     ST_User AS D ON D.Oid = A.AssignedTo LEFT OUTER JOIN 
			     CT_Ticket_Types AS I ON I.Oid = A.TicketType LEFT OUTER JOIN  CT_Ticket_States AS J ON A.TicketState=J.Oid 
             WHERE  A.TicketAramaTarihi > '2021' AND A.GCRecord IS NULL AND J.TicketStateDescription IN('Logoda Bekliyor') ) AS [WaitOnLogoSupportCount]
                    FROM MT_Ticket AS A 
                    WHERE (A.TicketAramaTarihi > '2021-01-01'  OR A.TicketCompletedDate>'2021-01-01') AND A.GCRecord IS NULL";


            var res = _crmRepository.GetCrmDashboardKpi(query);
            return res;
        }
        //public Response<CrmDashboardKpiViewModel> GetCrmDashboardKpi(string userOid)
        //{
        //    var date = DateTime.Now.AddDays(-7);//.ToString("yyyy-MM-dd");
        //    var query = @$"SELECT
        //                    (SELECT COUNT(1)
        //                        FROM MT_Ticket AS A INNER JOIN
        //                        ST_User AS D ON D.Oid = A.AssignedTo LEFT OUTER JOIN
        //                        CT_Ticket_States AS J ON A.TicketState=J.Oid
        //                        WHERE A.TicketAramaTarihi > '2021' AND A.GCRecord IS NULL AND J.TicketStateDescription NOT IN('Ücretli Kapandı','Tamamlandı','Logoda Bekliyor') ) AS [WaitingSupportCount]
        //                    ,(SELECT COUNT(1)
        //                        FROM MT_Ticket AS A INNER JOIN
        //                        ST_User AS D ON D.Oid = A.AssignedTo LEFT OUTER JOIN 
        //                        CT_Ticket_Types AS I ON I.Oid = A.TicketType LEFT OUTER JOIN  CT_Ticket_States AS J ON A.TicketState=J.Oid 
        //                        WHERE  A.TicketAramaTarihi > '2021' AND A.GCRecord IS NULL AND J.TicketStateDescription IN('Logoda Bekliyor') ) AS [WaitOnLogoSupportCount]
        //                    ,(SELECT COUNT(1)
        //                        FROM MT_Ticket AS A INNER JOIN  
        //                        ST_User AS D ON D.Oid = A.AssignedTo LEFT OUTER JOIN 
        //                        CT_Ticket_States AS J on A.TicketState=J.Oid
        //                        WHERE A._CreatedDateTime > '2021' AND A.GCRecord IS NULL AND J.TicketStateDescription NOT IN('Ücretli Kapandı','Tamamlandı','Logoda Bekliyor') 
        //                        AND A.AssignedTo='A0EFF398-D31A-4767-A1DE-445312C9E086' ) AS [WaitWebUserSupportCount]
        //                    ,(SELECT COUNT(1)
        //                        FROM MT_Ticket AS A INNER JOIN  
        //                        ST_User AS D ON D.Oid = A.AssignedTo LEFT OUTER JOIN 
        //                        CT_Ticket_States AS J on A.TicketState=J.Oid
        //                        WHERE A._CreatedDateTime > '2021' AND A.GCRecord IS NULL AND J.TicketStateDescription NOT IN('Ücretli Kapandı','Tamamlandı','Logoda Bekliyor') 
        //                        AND A.AssignedTo='F2028B99-C49E-4F4B-B1E7-69FF7ACF869A' ) AS [WaitWebUserSupportCount]
        //                     ,A.AssignedTo AS [ASign]
        //,A.TicketAramaTarihi
        //,J.TicketStateDescription
        //                     ,A.TicketCompletedDate
        //                     ,A.ActiveWorkingUser
        //                   FROM MT_Ticket AS A INNER JOIN  
        //                   ST_User AS D ON D.Oid = A.AssignedTo LEFT OUTER JOIN 
        //                   CT_Ticket_States AS J on A.TicketState=J.Oid
        //                   WHERE (A.TicketAramaTarihi > '{date.ToString("yyyy-MM-dd")}'  OR A.TicketCompletedDate>'{date.ToString("yyyy-MM-dd")}') AND A.GCRecord IS NULL";


        //    var res = _crmRepository.GetCrmDashboardKpi(query);
        //    if (!res.IsSuccess)
        //    {
        //        return Response<CrmDashboardKpiViewModel>.FailData(400, res.Message, res.Errors.Errors, true);
        //    }
        //    var firstLine = res.Data.FirstOrDefault();

        //    var retVal = new CrmDashboardKpiViewModel
        //    {
        //        WaitingSupportCount = 0,
        //        WaitOnLogoSupportCount = 0,
        //        WaitOnWaitingForAccessCount = 0,
        //        WaitWebUserSupportCount = 0,

        //        WeeklyOpenedForMeSupports = new List<int>() { 0, 0, 0, 0, 0, 0, 0 },
        //        WeeklyIcomplatedSupports = new List<int>() { 0, 0, 0, 0, 0, 0, 0 },
        //        WeeklyTotalOpenedSupports = new List<int>() { 0, 0, 0, 0, 0, 0, 0 },
        //        WeeklyOpenedFromWebsiteSupports = new List<int>() { 0, 0, 0, 0, 0, 0, 0 },
        //        WeeklyComplatedSupports = new List<int>() { 0, 0, 0, 0, 0, 0, 0 },
        //        Dates = new List<string>() { "", "", "", "", "", "", "" }
        //    };

        //    if (res.Data.Count < 1)
        //    {
        //        return Response<CrmDashboardKpiViewModel>.SuccessData(200, "Ticket listesi başarıyla alındı ancak görüntülenecek data bulunmuyor", retVal);
        //    }
        //    retVal.WaitingSupportCount = firstLine.WaitingSupportCount;
        //    retVal.WaitOnLogoSupportCount = firstLine.WaitOnLogoSupportCount;
        //    retVal.WaitOnWaitingForAccessCount = firstLine.WaitOnWaitingForAccess;
        //    retVal.WaitWebUserSupportCount = firstLine.WaitWebUserSupportCount;



        //    var weeklyOpenedForMeSupports = res.Data.Where(x => string.Equals(x.AssignedTo, userOid, StringComparison.CurrentCultureIgnoreCase)).ToList();

        //    var weeklyIcomplatedSupports = res.Data.Where(x =>
        //        (x.TicketState == "Tamamlandı" || x.TicketState == "Ücretli Kapandı" ||
        //        x.TicketState == "Logoda Bekliyor" || x.TicketState == "Destek Ücreti Onaylanmadı") && string.Equals(x.ActiveWorkingUser, userOid, StringComparison.CurrentCultureIgnoreCase) && x.CloseTime >= date).ToList();

        //    var weeklyTotalOpenedSupports = res.Data.Where(x => x.CallTime >= date).ToList();

        //    var weeklyComplatedSupports = res.Data.Where(x => x.CloseTime >= date && (
        //        x.TicketState == "Tamamlandı" || x.TicketState == "Ücretli Kapandı" ||
        //        x.TicketState == "Logoda Bekliyor" || x.TicketState == "Destek Ücreti Onaylanmadı")).ToList();

        //    var weeklyOpenedFromWebsiteSupports = res.Data.Where(x => string.Equals(x.AssignedTo, "A0EFF398-D31A-4767-A1DE-445312C9E08", StringComparison.CurrentCultureIgnoreCase)).ToList();





        //    for (int i = 0; i < 7; i++)
        //    {
        //        var addDate = i * -1;
        //        var gDate = DateTime.Now.AddDays(addDate);
        //        var index = 6 - i;
        //        retVal.Dates[index] = gDate.ToShortDateString();
        //        retVal.WeeklyOpenedForMeSupports[index] = weeklyOpenedForMeSupports.Count(x => x.CallTime.Day == gDate.Day && x.CallTime.Month == gDate.Month && x.CallTime.Year == gDate.Year);
        //        retVal.WeeklyIcomplatedSupports[index] = weeklyIcomplatedSupports.Count(x => x.CloseTime.Day == gDate.Day && x.CloseTime.Month == gDate.Month && x.CloseTime.Year == gDate.Year);
        //        retVal.WeeklyTotalOpenedSupports[index] = weeklyTotalOpenedSupports.Count(x => x.CallTime.Day == gDate.Day && x.CallTime.Month == gDate.Month && x.CallTime.Year == gDate.Year);
        //        retVal.WeeklyOpenedFromWebsiteSupports[index] = weeklyOpenedFromWebsiteSupports.Count(x => x.CallTime.Day == gDate.Day && x.CallTime.Month == gDate.Month && x.CallTime.Year == gDate.Year);
        //        retVal.WeeklyComplatedSupports[index] = weeklyComplatedSupports.Count(x => x.CloseTime.Day == gDate.Day && x.CloseTime.Month == gDate.Month && x.CloseTime.Year == gDate.Year);
        //        //weekliComplatedSupports.Count(x => x.CallTime == DateTime.Now.AddDays(i*-1));
        //    }

        //    return Response<CrmDashboardKpiViewModel>.SuccessData(200, "Destek Kaydı İstatistikleri Başarıyla Alındı", retVal);
        //}

        public Response<string> GetFirmOidByPhone(string phone)
        {
            var query = $@"SELECT DISTINCT 
                                 F.Oid AS ID
                                ,F.FirmCode AS 'FİRMA KODU'
                                ,F.FirmTitle AS 'FİRMA ADI'
                                , (ISNULL(P.AreaCode,'') + ISNULL(P.NUMBER,'')) AS 'TELEFON' 
                          FROM MT_Firm AS F LEFT JOIN 
                          MT_Contact AS C ON C.RelatedFirm=F.Oid LEFT JOIN
                          	    PO_Phone_Number AS P ON P.RelatedFirm=F.Oid OR P.RelatedContact=C.Oid
                          WHERE (ISNULL(P.AreaCode,'') + ISNULL(P.NUMBER,''))='{phone}'";
            try
            {
                var res = _sqlProvider.SqlReader(_configuration.GetConnectionString("CrmConnection"), query);
                if (res.IsSuccess)
                {
                    if (res.Data.Rows.Count < 1)
                    {
                        return Response<string>.FailData(400, "Bu Telefon Numarasına Ait Firma Bilgisine Ulaşılamadı", "Telefon Numarası CRM Sistemine Kayıtlı Değil", true);
                    }
                    var oid = res.Data.Rows[0][0].ToString();
                    return Response<string>.SuccessData(200, "Firma Bilgileri Bulundu", oid);
                }
                else
                {
                    return Response<string>.FailData(400, "Bu Telefon Numarasına Ait Firma Bilgisine Ulaşılamadı", "Telefon Numarası CRM Sistemine Kayıtlı Değil", true);
                }
            }
            catch (Exception ex)
            {
                return Response<string>.FailData(400, "Firma Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<List<CrmDailySupportChartViewModel>>> GetCrmDailyClosedSupportCount()
        {
            var date = DateTime.Now;
            var sDate = $"{date.ToString("yyyy-MM-dd")} 00:01";
            var eDate = $"{date.ToString("yyyy-MM-dd")} 23:59";
            var query1 = $@"Select U.Oid AS 'USEROID',U.Caption AS 'USERNAME', Count(U.Caption) AS 'COUNT',STRING_AGG(T.TicketId,', ') AS 'TICKETIDS' 
                            FROM MT_Ticket AS T INNER JOIN ST_User AS U  ON U.Oid=T.ActiveWorkingUser
                            WHERE T.IsCompleted=1 AND T.TicketCompletedDate BETWEEN  '{sDate}' AND '{eDate}'
                            Group By U.Caption,U.Oid
                            Having COUNT (U.Caption) > 0";
            var query2 = $@"SELECT  ActiveWorkingUser AS 'USEROID',FORMAT(CAST(TicketCompletedDate AS datetime2), N'HH:mm') AS 'TIME' ,F.FirmTitle AS 'FIRM TITLE'
                            FROM MT_Ticket AS T INNER JOIN
                            MT_Firm AS F ON F.Oid=T.TicketFirm
                            WHERE T.IsCompleted=1 AND T.TicketCompletedDate BETWEEN  '{sDate}' AND '{eDate}'";
            try
            {
                var res = await _crmRepository.GetCrmDailyClosedSupportCount(query1, query2);
                return res;
            }
            catch (Exception ex)
            {
                return Response<List<CrmDailySupportChartViewModel>>.FailData(400, "Firma Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<List<CrmDailySupportChartViewModel>>> GetCrmApointedSupportCount()
        {
            var query = $@"select U.Oid AS 'USEROID',F.FirmTitle as 'Firm',T.TicketId AS 'Ticket',U.Caption AS 'USERNAME',DATEDIFF(DAY, T.TicketAramaTarihi,GETDATE()) as 'Beleme Zamanı' from MT_Ticket as T inner join
                                ST_User as U on T.AssignedTo = U.Oid inner join
                                MT_Firm as F on T.TicketFirm= F.Oid
                                where T._CreatedDateTime > '2023-01-01'  and U.Oid not in('A0EFF398-D31A-4767-A1DE-445312C9E086','F2028B99-C49E-4F4B-B1E7-69FF7ACF869A') and
                                T.ActiveWorkingUser is null and
                                t.TicketState in (
                                 '7AD9A7AE-AD2C-4CAA-BE50-42130D1EB57F'
                                ,'F3D3AD27-FFBF-48C2-B2A6-5761BC6E45E0'
                                ,'5D982B4A-4D94-43F2-960F-834743CBE1B0'
                                ,'56C7DB4D-EFB7-4103-952D-84A719C94020'
                                ,'B61F4BCF-B108-4676-8EDE-91AC3538E916'
                                ,'B35C770E-7D9E-4523-B3F6-C61BA273B61C'
                                ,'C6DAF753-63BF-4825-9476-D38872472727'
                                ,'2E1076A9-7B80-418A-A8BD-D72074D577B6'
                                )
                                Group By U.Caption,U.Oid,T.TicketId,F.FirmTitle,T.TicketAramaTarihi
                                Having COUNT (U.Caption) > 0
                                union
                                select U.Oid AS 'USEROID',F.FirmTitle as 'Firm',T.TicketId AS 'Ticket',U.Caption AS 'USERNAME',DATEDIFF(DAY, T.TicketAramaTarihi,GETDATE()) as 'Beleme Zamanı' from MT_Ticket as T inner join
                                ST_User as U on T.ActiveWorkingUser = U.Oid inner join
                                MT_Firm as F on T.TicketFirm= F.Oid
                                where T._CreatedDateTime > '2023-01-01' and U.Oid not in('A0EFF398-D31A-4767-A1DE-445312C9E086','F2028B99-C49E-4F4B-B1E7-69FF7ACF869A')  and
                                t.TicketState in (
                                 '7AD9A7AE-AD2C-4CAA-BE50-42130D1EB57F'
                                ,'F3D3AD27-FFBF-48C2-B2A6-5761BC6E45E0'
                                ,'5D982B4A-4D94-43F2-960F-834743CBE1B0'
                                ,'56C7DB4D-EFB7-4103-952D-84A719C94020'
                                ,'B61F4BCF-B108-4676-8EDE-91AC3538E916'
                                ,'B35C770E-7D9E-4523-B3F6-C61BA273B61C'
                                ,'C6DAF753-63BF-4825-9476-D38872472727'
                                ,'2E1076A9-7B80-418A-A8BD-D72074D577B6'
                                )
                                Group By U.Caption,U.Oid,T.TicketId,F.FirmTitle,T.TicketAramaTarihi
                                Having COUNT (U.Caption) > 0";

            try
            {
                var res = await _crmRepository.GetCrmOpenSupportChartData(query);
                if (!res.IsSuccess)
                {
                    return Response<List<CrmDailySupportChartViewModel>>.FailData(400, "Firma Bilgisi Alınırken Bir Sorunla Karşılaşıldı", res.Errors.Errors, false);
                }
                var retVal = new List<CrmDailySupportChartViewModel>();
                var groupedData = res.Data.GroupBy(x => x.UserId);
                var avatars = await _userRepository.GetUserAvatarList(res.Data.Select(x => x.UserId).ToList());
                foreach (var item in groupedData)
                {
                    var model = new CrmDailySupportChartViewModel
                    {
                        Count = item.Count(),
                        UserId = item.First().UserId,
                        Label = item.First().UserName,
                        TicketNumbers = string.Join(", ", item.Select(x => x.TicketNumbers)),
                        UserSupportDeatils = new List<CrmUserDailySupportInfoViewModel>()
                    };

                    model.Avatar = avatars.FirstOrDefault(x => x.Key.Equals(model.UserId, StringComparison.OrdinalIgnoreCase)).Value;
                    if (string.IsNullOrEmpty(model.Avatar))
                    {
                        model.Avatar = "KoalaNoPic.png";
                    }

                    foreach (var item2 in item)
                    {
                        var dModel = new CrmUserDailySupportInfoViewModel
                        {
                            UserId = item2.UserId,
                            Time = item2.PassingDay,
                            Firm = item2.Firm,
                            UserFullName = item2.UserName
                        };
                        model.UserSupportDeatils.Add(dModel);
                    }
                    retVal.Add(model);
                }
                return Response<List<CrmDailySupportChartViewModel>>.SuccessData(200, "Firma Bilgisi Alınırken Bir Sorunla Karşılaşıldı", retVal);
                //return res;
            }
            catch (Exception ex)
            {
                return Response<List<CrmDailySupportChartViewModel>>.FailData(400, "Grafik Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
    }
}
