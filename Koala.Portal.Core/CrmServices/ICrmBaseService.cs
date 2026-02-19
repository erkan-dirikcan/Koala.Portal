using Koala.Portal.Core.Dtos;
using System.Linq.Expressions;

namespace Koala.Portal.Core.CrmServices
{
    public interface ICrmBaseService<TEntity> where TEntity : class
    {
        Task<Response<TEntity>?> GetByIdAsyc(string id);
        Task<Response<IEnumerable<TEntity>>> GetAllAsyc();
        Task<Response<IEnumerable<TEntity>>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<Response<TEntity>> AddAsyc(TEntity dto);
        Task<Response> Delete(string id);
        Task<Response> Update(TEntity dto, string id);
    }
}
