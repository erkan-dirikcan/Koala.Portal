using System.Linq.Expressions;
using Koala.Portal.Core.Adapters;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class FirmRepository : IFirmRepository
    {
        private readonly SistemCrmContext _crmContext;
        private readonly ICrmFirmAdapter _firmAdapter;
        private readonly ICrmContactAdapter _contactAdapter;

        public FirmRepository(SistemCrmContext crmContext, ICrmFirmAdapter firmAdapter, ICrmContactAdapter contactAdapter)
        {
            _crmContext = crmContext;
            _firmAdapter = firmAdapter;
            _contactAdapter = contactAdapter;
        }

        // NOTE: AddRangeAsync and UpdateFirmAsync are kept for backward compatibility
        // but they will not work with CRM data (CRM is read-only for this app)
        public async Task AddRangeAsync(List<CrmFirm> firms)
        {
            // No-op - CRM is read-only
            await Task.CompletedTask;
        }

        public CrmFirm? GetFirmInfoById(string id)
        {
            // Since local entities are no longer used, query CRM directly by Oid
            // The 'id' parameter now represents the CRM Oid (not local Id)
            if (Guid.TryParse(id, out Guid oid))
            {
                var crmFirm = _crmContext.MT_Firm
                    .Include(f => f.PO_Phone_Number)
                    .Include(f => f.MT_Contact)
                        .ThenInclude(c => c.PO_Phone_Number)
                    .FirstOrDefault(f => f.Oid == oid && f.GCRecord == null);

                if (crmFirm != null)
                {
                    return _firmAdapter.ToLocalEntityWithPhones(crmFirm, crmFirm.PO_Phone_Number);
                }
            }
            return null;
        }

        public async Task UpdateFirmAsync(CrmFirm entity)
        {
            // No-op - CRM is read-only
            await Task.CompletedTask;
        }

        public IQueryable<CrmFirm> Where(Expression<Func<CrmFirm, bool>> predicate)
        {
            // Since we need to transform CRM data, we can't return a true IQueryable
            // Load all active firms and return as in-memory queryable
            var firms = _crmContext.MT_Firm
                .Include(f => f.PO_Phone_Number)
                .Include(f => f.MT_Contact)
                    .ThenInclude(c => c.PO_Phone_Number)
                .Where(f => f.InUse == true && f.GCRecord == null)
                .AsEnumerable()
                .Select(f => _firmAdapter.ToLocalEntityWithPhones(
                    f,
                    f.PO_Phone_Number
                ))
                .Where(f => f != null)
                .AsQueryable();

            return firms.Where(predicate);
        }

        public async Task<IEnumerable<CrmFirm>> GetAllAsync()
        {
            try
            {
                var firms = await _crmContext.MT_Firm
                    .Include(f => f.PO_Phone_Number)
                    .Include(f => f.MT_Contact)
                        .ThenInclude(c => c.PO_Phone_Number)
                    .Where(f => f.GCRecord == null)
                    .ToListAsync();

                return firms
                    .Select(f => _firmAdapter.ToLocalEntityWithPhones(f, f.PO_Phone_Number))
                    .Where(f => f != null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
