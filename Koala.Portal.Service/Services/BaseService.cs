using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using System.Linq.Expressions;
using Koala.Portal.Repository;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IBaseRepository<TEntity> _baseRepository;


        public BaseService(IUnitOfWork<AppDbContext> unitOfWork, IBaseRepository<TEntity> baseRepository)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }

        public async Task<Response<TEntity>> AddAsyc(TEntity entity)
        {
            await _baseRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return Response<TEntity>.SuccessData(200,"", entity);
        }

        public async Task<Response<IEnumerable<TEntity>>> GetAllAsync()
        {
            try     
            {
                var items = await _baseRepository.GetAllAsync();
                return Response<IEnumerable<TEntity>>.SuccessData(200, "Liste Başarıyla Alındı", items);
            }
            catch (Exception ex)
            {

                return Response<IEnumerable<TEntity>>.FailData(400, "Liste Başarıyla Alındı", ex.Message,false);
            }
        }

        public async Task<Response<TEntity>?> GetByIdAsyc(string id)
        {
            var res = await _baseRepository.GetByIdAsync(id);
            return Response<TEntity>.SuccessData(200,"Nesne Bilgisi Başarıyla Alındı",res);

        }

        public async Task<Response> Update(TEntity entity, string id)
        {
            var isExsistEntity = await _baseRepository.GetByIdAsync(id);
            _baseRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return Response.Success(200, "Güncelleme İşlemi Başarılı");
        }

        public async Task<Response<IEnumerable<TEntity>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var res =await _baseRepository.Where(predicate).ToListAsync();
            return Response<IEnumerable<TEntity>>.SuccessData(200,"", res);
        }

        public async Task<Response> Delete(string id)
        {
            var isExsistEntity = await _baseRepository.GetByIdAsync(id);
            _baseRepository.Delete(isExsistEntity);

            return Response.Success(200, "Silinmek İstenilen Kayıt Veri Tabanında Bulunamadı.");
        }
    }
}
