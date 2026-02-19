using System.Linq.Expressions;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.GetPassRepositories;
using Koala.Portal.Core.GetPassServices;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Service.GetPassServices
{
	public class GetPassBaseService<TEntity> : IGetPassBaseService<TEntity> where TEntity : class
	{
		private readonly IGetPassBaseRepository<TEntity> _baseRepository;
		public GetPassBaseService(IGetPassBaseRepository<TEntity> baseRepository)
		{
			_baseRepository = baseRepository;
		}


		public async Task<Response<TEntity>> AddAsyc(TEntity entity)
		{
			await _baseRepository.AddAsyc(entity);
      
			return Response<TEntity>.SuccessData(200, "", entity);
		}


		public async Task<Response<IEnumerable<TEntity>>> GetAllAsyc()
		{
			var items = await _baseRepository.GetAllAsyc();
			return Response<IEnumerable<TEntity>>.SuccessData(200, "Liste Başarıyla Alındı", items);
		}

		public async Task<Response<TEntity>?> GetByIdAsyc(string id)
		{
			var res = await _baseRepository.GetByIdAsyc(id);
			return Response<TEntity>.SuccessData(200, "Nesne Bilgisi Başarıyla Alındı", res);

		}

		public async Task<Response> Update(TEntity entity, string id)
		{
			var isExsistEntity = await _baseRepository.GetByIdAsyc(id);
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
			var isExsistEntity = await _baseRepository.GetByIdAsyc(id);
			if (isExsistEntity != null) _baseRepository.Delete(isExsistEntity);

			return Response.Success(200, "Silinmek İstenilen Kayıt Veri Tabanında Bulunamadı.");
		}
	}
}
