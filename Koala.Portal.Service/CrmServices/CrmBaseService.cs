using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Koala.Portal.Service.CrmServices
{
    public class CrmBaseService<TEntity> : ICrmBaseService<TEntity> where TEntity : class
    {
        private readonly ICrmBaseRepository<TEntity> _baseRepository;
        public CrmBaseService(ICrmBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }


        public async Task<Response<TEntity>> AddAsyc(TEntity entity)
        {
            await _baseRepository.AddAsync(entity);
         
            return Response<TEntity>.SuccessData(200, "", entity);
        }


        public async Task<Response<IEnumerable<TEntity>>> GetAllAsyc()
        {
            var items = await _baseRepository.GetAllAsyc();
            return Response<IEnumerable<TEntity>>.SuccessData(200, "Liste Başarıyla Alındı", items);
        }

        public async Task<Response<TEntity>?> GetByIdAsyc(string id)
        {
            var res = await _baseRepository.GetByIdAsync(id);
            return Response<TEntity>.SuccessData(200, "Nesne Bilgisi Başarıyla Alındı", res);

        }

        public async Task<Response> Update(TEntity entity, string id)
        {
            var isExsistEntity = await _baseRepository.GetByIdAsync(id);
            _baseRepository.Update(entity);
            return Response.Success(200, "Güncelleme İşlemi Başarılı");
        }

        public async Task<Response<IEnumerable<TEntity>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var res = await _baseRepository.Where(predicate).ToListAsync();
            return Response<IEnumerable<TEntity>>.SuccessData(200, "", res);
        }

        public async Task<Response> Delete(string id)
        {
            var isExsistEntity = await _baseRepository.GetByIdAsync(id);
            _baseRepository.Delete(isExsistEntity);

            return Response.Success(200, "Silinmek İstenilen Kayıt Veri Tabanında Bulunamadı.");
        }
    }
}
