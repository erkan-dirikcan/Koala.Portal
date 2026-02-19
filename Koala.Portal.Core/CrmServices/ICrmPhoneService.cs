using Koala.Portal.Core.CrmModels;
using System.Linq.Expressions;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.CrmServices;

public interface ICrmPhoneService
{
    Response<List<CrmPhoneNumberInfoViewModel>> Where(Expression<Func<PO_Phone_Number, bool>> predicate);
}