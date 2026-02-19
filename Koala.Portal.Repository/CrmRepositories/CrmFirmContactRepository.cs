using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using System.Linq.Expressions;

namespace Koala.Portal.Repository.CrmRepositories
{
    public class CrmContactRepository : ICrmContactRepository
    {
        public MT_Contact? GetFirmContactInfo(string contactOid)
        {
            throw new NotImplementedException();
        }

        public void UpdateFirmContact(MT_Contact model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MT_Contact> Where(Expression<Func<MT_Contact, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}



/*
 
 */