using Koala.Portal.Core.CrmModels;
using System.Linq.Expressions;

namespace Koala.Portal.Core.CrmRepositories
{
    public interface ICrmFirmRepository
    {
        IQueryable<MT_Firm> Where(Expression<Func<MT_Firm, bool>> predicate);
        MT_Firm? GetFirmSupportStatusInfo(string firmOid);
        MT_Firm? GetFirmInfo(string firmOid);
        MT_Firm? GetFirmInfoByCode(string code);
        /// <summary>
        /// Gets all firms from CRM database
        /// </summary>
        Task<List<MT_Firm>> GetAllAsync();
        //IEnumerable<MT_Firm> GetFirmInfoWithPhone(string phone);
        //IEnumerable<MT_Firm> GetFirmInfoWithEmail(string email);
    }
}