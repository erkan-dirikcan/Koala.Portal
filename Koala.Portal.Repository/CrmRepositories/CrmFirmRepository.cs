using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.CrmRepositories
{
    public class CrmFirmRepository : ICrmFirmRepository
    {
        SistemCrmContext _context;
        public readonly DbSet<MT_Firm?> _dbSet;
        public CrmFirmRepository(SistemCrmContext context)
        {
            _context = context;
            _dbSet = context.Set<MT_Firm>();
        }
        public IQueryable<MT_Firm> Where(Expression<Func<MT_Firm, bool>> predicate)
        {
            return _dbSet.Include(x => x.MT_Contact).Where(predicate);

        }

        public MT_Firm? GetFirmSupportStatusInfo(string firmOid)
        {
            return _dbSet.FirstOrDefault(x => x.Oid == new Guid(firmOid));
        }

        public MT_Firm? GetFirmInfo(string firmOid)
        {
            return _dbSet.Include(x=>x.PO_Phone_Number).Include(x=>x.MT_Contact).FirstOrDefault(x => x.Oid == new Guid(firmOid));
        }

        public MT_Firm? GetFirmInfoByCode(string code)
        {
            return _dbSet.Include(x=>x.PO_Phone_Number).Include(x=>x.MT_Contact).FirstOrDefault(x => x.FirmCode == code);
        }

        public async Task<List<MT_Firm>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.PO_Phone_Number)
                                  .Include(x => x.MT_Contact)
                                  .Where(x => x.InUse == true)
                                  .ToListAsync();
        }

        //public IEnumerable<MT_Firm> GetFirmInfoWithPhone(string phone)
        //{
        //    //var phones = _context.PO_Phone_Number.Include(x => x.RelatedContactNavigation)
        //    //                                                            .Include(x => x.RelatedFirmNavigation)
        //    //                                                            .Where(x => x.Number == phone.Substring(3, 7) && 
        //    //                                                                                     x.AreaCode==phone.Substring(0,3));

        //    var res= _dbSet.Include(x => x.MT_Contact)
        //                 .Include(x => x.PO_Phone_Number)
        //                 .Where(x => x.PO_Phone_Number.Any(y => y.Number == phone.Substring(3,7) && y.Number == phone.Substring(0,3)));
        //    return res;
        //}

        //public IEnumerable<MT_Firm> GetFirmInfoWithEmail(string email)
        //{
        //    return _dbSet.Include(x => x.MT_Contact)
        //                 .Include(x => x.PO_Phone_Number)
        //                 .Where(x => x.MT_Contact.Any(y => y.EmailAddress1 == email || 
        //                                                                    y.EmailAddress2 == email || 
        //                                                                    y.EmailAddress3 == email));
        //}
    }
}
