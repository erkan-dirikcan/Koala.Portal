using System.Linq.Expressions;
using Koala.Portal.Core.Adapters;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class FirmContactRepository : IFirmContactRepository
    {
        private readonly SistemCrmContext _crmContext;
        private readonly ICrmContactAdapter _contactAdapter;
        private readonly ICrmPhoneAdapter _phoneAdapter;

        public FirmContactRepository(SistemCrmContext crmContext, ICrmContactAdapter contactAdapter, ICrmPhoneAdapter phoneAdapter)
        {
            _crmContext = crmContext;
            _contactAdapter = contactAdapter;
            _phoneAdapter = phoneAdapter;
        }

        public async Task<IEnumerable<CrmFirmContact>> GetAllAsync(string firmId)
        {
            // firmId is local Id which doesn't exist in CRM
            // Return empty - callers should use GetAllByOidAsync instead
            return await Task.FromResult(Enumerable.Empty<CrmFirmContact>());
        }

        public async Task<IEnumerable<CrmFirmContact>> GetAllByOidAsync(string firmOid)
        {
            if (!Guid.TryParse(firmOid, out Guid firmGuid))
            {
                return Enumerable.Empty<CrmFirmContact>();
            }

            var contacts = await _crmContext.MT_Contact
                .Include(c => c.PO_Phone_Number)
                .Where(c => c.RelatedFirm == firmGuid && c.GCRecord == null)
                .ToListAsync();

            return contacts
                .Select(c => _contactAdapter.ToLocalEntity(c, firmOid))
                .Where(c => c != null);
        }

        public IQueryable<CrmFirmContact> Where(Expression<Func<CrmFirmContact, bool>> predicate)
        {
            var contacts = _crmContext.MT_Contact
                .Include(c => c.PO_Phone_Number)
                .Where(c => c.GCRecord == null)
                .AsEnumerable()
                .Select(c => _contactAdapter.ToLocalEntity(c))
                .Where(c => c != null)
                .AsQueryable();

            return contacts.Where(predicate);
        }

        public async Task<CrmFirmContact?> GetByIdAsync(string id)
        {
            // Local Id doesn't exist in CRM
            return await Task.FromResult<CrmFirmContact>(null);
        }

        public async Task<CrmFirmContact?> GetByOidAsync(string oid)
        {
            if (!Guid.TryParse(oid, out Guid contactGuid))
            {
                return null;
            }

            var contact = await _crmContext.MT_Contact
                .Include(c => c.PO_Phone_Number)
                .FirstOrDefaultAsync(c => c.Oid == contactGuid && c.GCRecord == null);

            if (contact == null) return null;

            return _contactAdapter.ToLocalEntity(contact);
        }
    }
}
