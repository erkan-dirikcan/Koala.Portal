using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Providers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace Koala.Portal.Repository.CrmRepositories
{
    public class CrmSelectListRepository : ICrmSelectListRepository
    {
        private readonly ICrmSqlProvider _provider;
        private readonly IConfiguration _configuration;
        private readonly string _crmConnectionString;
        //private readonly ILogger _logger;
        public CrmSelectListRepository(ICrmSqlProvider provider, IConfiguration configuration)
        {
            _provider = provider;
            _configuration = configuration;
            _crmConnectionString = _configuration.GetConnectionString("CrmConnection")!;
        }

        public Task<Response<List<SelectListItem>>> GetUserSelectList(bool withMail, string selected = "")
        {
            const string query = $@"SELECT Oid,Caption,EMailAddress FROM ST_User WHERE IsActive=1 AND EMailAddress IS NOT NULL ";

            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));
                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }

            var items = new List<SelectListItem>();
            for (var i = 0; i < res.Data.Rows.Count; i++)
            {
                var model = new SelectListItem
                {

                    Text = withMail ? $"{res.Data.Rows[i][1]} - ({res.Data.Rows[i][2]})" : $"{res.Data.Rows[i][1]}",
                    Selected = string.Equals(selected, res.Data.Rows[i][0].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = res.Data.Rows[i][0].ToString()!
                };
                items.Add(model);
            }

            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm kullanıcı listesi başarıyla alındı", items));
        }

        public Task<Response<List<SelectListItem>>> GetFirmSelectList(string selected = "")
        {
            const string query = $@"SELECT Oid,FirmCode,FirmTitle FROM MT_Firm where GCRecord IS NULL AND InUse=1";
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));
                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }

            var items = new List<SelectListItem>();
            for (var i = 0; i < res.Data.Rows.Count; i++)
            {
                var model = new SelectListItem
                {
                    Text = $"({res.Data.Rows[i][1]}) - {res.Data.Rows[i][2]}",
                    Selected = string.Equals(selected, res.Data.Rows[i][0].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = res.Data.Rows[i][0].ToString()!,

                };
                items.Add(model);
            }

            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm firma listesi başarıyla alındı", items));
        }

        public Task<Response<List<SelectListItem>>> GetFirmContactListWithOid(string firmOid, string selected = "")
        {
            var query = $@"select Oid,FullName,EmailAddress1 from MT_Contact where RelatedFirm='{firmOid}' and EmailAddress1 is not null and LEN(EmailAddress1)>4  AND InUse=1";
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));
                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }
            var items = new List<SelectListItem>();
            for (var i = 0; i < res.Data.Rows.Count; i++)
            {
                if (!Tools.IsValidEmail($"{res.Data.Rows[i][2]}"))
                {
                    continue;
                }
                var model = new SelectListItem
                {
                    Text = $"{res.Data.Rows[i][1]}",
                    Selected = string.Equals(selected, res.Data.Rows[i][0].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = res.Data.Rows[i][0].ToString()!
                };
                items.Add(model);

            }


            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm firma kontak listesi başarıyla alındı", items));
        }

       

        public Task<Response<List<SelectListItem>>> GetFirmContactMailList(string contactOid, string selected = "")
        {
            var query = $@"select EmailAddress1,EmailAddress2,EmailAddress3 from MT_Contact where Oid='{contactOid}'  AND InUse=1";
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));
                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }
            var items = new List<SelectListItem>();

            if (res.Data.Rows[0][0] != null && res.Data.Rows[0][0].ToString().Length > 4)
            {
                items.Add(new SelectListItem
                {
                    Text = $"{res.Data.Rows[0][0]}",
                    Selected = string.Equals(selected, res.Data.Rows[0][0].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = $"{res.Data.Rows[0][0]}"
                });
            }
            if (res.Data.Rows[0][1] != null && res.Data.Rows[0][1].ToString().Length > 4)
            {
                items.Add(new SelectListItem
                {
                    Text = $"{res.Data.Rows[0][1]}",
                    Selected = string.Equals(selected, res.Data.Rows[0][1].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = $"{res.Data.Rows[0][1]}"
                });
            }
            if (res.Data.Rows[0][2] != null && res.Data.Rows[0][2].ToString().Length > 4)
            {
                items.Add(new SelectListItem
                {
                    Text = $"{res.Data.Rows[0][2]}",
                    Selected = string.Equals(selected, res.Data.Rows[0][2].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = $"{res.Data.Rows[0][2]}"
                });
            }

            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm kontak mail listesi başarıyla alındı", items));
        }

        public Task<Response<List<SelectListItem>>> GetFirmSupportList(string firmOid, string selected)
        {
            var query = $@"SELECT TC.Oid AS Oid,TC.TicketId AS [Ticket Number],ISNULL(TC.TicketDescription,'') AS [Ticket Description] 
                           FROM MT_Ticket AS TC INNER JOIN 
                           CT_Ticket_States AS TS ON TC.TicketState = TS.Oid 
                           WHERE TicketFirm='{firmOid}' AND TC.GCRecord IS NULL AND TS.TicketStateDescription NOT IN ('Tamamlandı','Ücretli Kapandı','Logoda Bekliyor')";
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));
                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }
            var items = new List<SelectListItem>();
            for (var i = 0; i < res.Data.Rows.Count; i++)
            {
                var model = new SelectListItem
                {
                    Text = $"({res.Data.Rows[i][1]}) - {res.Data.Rows[i][2]}",
                    Selected = string.Equals(selected, res.Data.Rows[i][0].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = res.Data.Rows[i][0].ToString()!,

                };
                items.Add(model);
            }

            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm firma destek listesi başarıyla alındı", items));
        }

        public Task<Response<List<SelectListItem>>> GetSupportDepartmentList(string selected = "")
        {
            const string query = $@"SELECT Oid,DepartmentName FROM CT_User_Departments WHERE GCRecord IS NULL";
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));
                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }

            var items = new List<SelectListItem>();
            for (var i = 0; i < res.Data.Rows.Count; i++)
            {
                var model = new SelectListItem
                {
                    Text = $"{res.Data.Rows[i][1]}",
                    Value = res.Data.Rows[i][0].ToString()!,
                    Selected = string.Equals(selected, res.Data.Rows[i][0].ToString(), StringComparison.CurrentCultureIgnoreCase)
                };
                items.Add(model);
            }

            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm departman listesi başarıyla alındı", items));
        }

        public Task<Response<List<SelectListItem>>> GetDepartmentUserSelectList(string departmentOid, string selected = "")
        {
            string query = $@"select us.Oid,us.Caption from CT_User_Departments as dp left join 
                                    RL_Users_Departments as ud on ud.DepartmentOid=dp.Oid left join 
                                    ST_User as us on us.Oid=ud.UserOid
                                    where us.IsActive=1 and dp.GCRecord is null and dp.Oid='{departmentOid}'
                                    order by us.Caption";

            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));
                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }

            var items = new List<SelectListItem>();
            for (var i = 0; i < res.Data.Rows.Count; i++)
            {
                var model = new SelectListItem
                {
                    Text = $"{res.Data.Rows[i][1]}",
                    Selected = string.Equals(selected, res.Data.Rows[i][0].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = res.Data.Rows[i][0].ToString()!
                };
                items.Add(model);
            }

            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm kullanıcı listesi başarıyla alındı", items));
        }

        public Task<Response<List<SelectListItem>>> GetSupportCategoryList(string selected = "")
        {
            const string query = $@"SELECT Oid,TicketMainCategoryDescription FROM CT_Ticket_Main_Category WHERE GCRecord IS NULL";
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));
                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }
            var items = new List<SelectListItem>();

            for (var i = 0; i < res.Data.Rows.Count; i++)
            {
                var model = new SelectListItem
                {
                    Text = $"{res.Data.Rows[i][1]}",
                    Selected = string.Equals(selected, res.Data.Rows[i][0].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = res.Data.Rows[i][0].ToString()!,
                };
                items.Add(model);
            }

            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm destek kategori listesi başarıyla alındı", items));
        }

        public Task<Response<List<SelectListItem>>> GetSupportSubCategoryList(string categoryOid, string selected = "")
        {
            var query = $@"SELECT Oid,TicketSubCategoryDescription FROM CT_Ticket_Sub_Category WHERE GCRecord IS NULL AND MainCategory='{categoryOid}'";
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {
                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));
                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }

            var items = new List<SelectListItem>();
            for (var i = 0; i < res.Data.Rows.Count; i++)
            {
                var model = new SelectListItem
                {
                    Text = $"{res.Data.Rows[i][1]}",
                    Selected = string.Equals(selected, res.Data.Rows[i][0].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = res.Data.Rows[i][0].ToString()!,
                };
                items.Add(model);
            }

            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm destek alt kategori listesi başarıyla alındı", items));
        }

        public Task<Response<List<SelectListItem>>> GetSupportTypeSelectList(string selected = "")
        {
            const string query = $@"SELECT Oid,TicketTypeDescription FROM CT_Ticket_Types WHERE GCRecord IS NULL";
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));

                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }

            var items = new List<SelectListItem>();
            for (var i = 0; i < res.Data.Rows.Count; i++)
            {
                var model = new SelectListItem
                {
                    Text = $"{res.Data.Rows[i][1]}",
                    Selected = string.Equals(selected, res.Data.Rows[i][0].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = res.Data.Rows[i][0].ToString()!,
                };
                items.Add(model);
            }

            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm destek tipleri listesi başarıyla alındı", items));
        }

        public Task<Response<List<SelectListItem>>> GetSupportStateSelectList(List<string> selected )
        {
            const string query = $@"SELECT Oid,TicketStateDescription FROM CT_Ticket_States WHERE GCRecord IS NULL";
            var res = _provider.SqlReader(_crmConnectionString, query);
            if (!res.IsSuccess)
            {                //_logger.Log(LogLevel.Error, string.Join(", ", res.Errors.Errors));

                return Task.FromResult(Response<List<SelectListItem>>.FailData(res.StatusCode, res.Message, res.Errors.Errors, true));
            }

            var items = new List<SelectListItem>();
            for (var i = 0; i < res.Data.Rows.Count; i++)
            {
                var model = new SelectListItem
                {
                    Text = $"{res.Data.Rows[i][1]}",
                    Selected = selected.Any(x => x == res.Data.Rows[i][0].ToString()), //string.Equals(selected, res.Data.Rows[i][0].ToString(), StringComparison.CurrentCultureIgnoreCase),
                    Value = res.Data.Rows[i][0].ToString()!,
                };
                items.Add(model);
            }

            return Task.FromResult(Response<List<SelectListItem>>.SuccessData(200, "Crm destek durumları listesi başarıyla alındı", items));
        }

       
    }
}
