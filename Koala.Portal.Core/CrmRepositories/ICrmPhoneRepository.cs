using Koala.Portal.Core.CrmModels;
using System.Linq.Expressions;

namespace Koala.Portal.Core.CrmRepositories;

public interface ICrmPhoneRepository
{
    IQueryable<PO_Phone_Number> Where(Expression<Func<PO_Phone_Number, bool>> predicate);
}