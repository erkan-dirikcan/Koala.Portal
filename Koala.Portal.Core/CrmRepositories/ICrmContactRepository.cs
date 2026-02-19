using Koala.Portal.Core.CrmModels;
using System.Linq.Expressions;

namespace Koala.Portal.Core.CrmRepositories
{
    public interface ICrmContactRepository
    {

        IQueryable<MT_Contact> Where(Expression<Func<MT_Contact, bool>> predicate);
        MT_Contact? GetFirmContactInfo(string contactOid);
        void UpdateFirmContact(MT_Contact model);
        
    }
}