using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;

namespace Koala.Portal.Service.Services
{
    public class FixtureService : IFixtureService
    {
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IFixtureRepository _repository;
        private readonly IMapper _mapper;
        public FixtureService(IUnitOfWork<AppDbContext> unitOfWork, IFixtureRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<Response<DetailFixtureViewModel>?> GetByIdAsyc(string id)
        {
            try
            {
                var res = await _repository.GetByIdAsync(id);
                return res == null ?
                    Response<DetailFixtureViewModel>.FailData(404, "Bilgileri Alınmak İstenen Demirbaş Bilgilerine Ulaşılamadı", "Bilgileri Alınmak İstenen Demirbaş Bilgilerine Ulaşılamadı. Id: " + id, true) :
                    Response<DetailFixtureViewModel>.SuccessData(200, "Demirbaş Bilgileri Başarıyla Alındı", _mapper.Map<DetailFixtureViewModel>(res));
            }
            catch (Exception ex)
            {
                return Response<DetailFixtureViewModel>.FailData(400, "Bilgileri Alınmak İstenen Demirbaş Bilgilerine Ulaşılamadı", ex.Message, false);
            }
        }
        public async Task<Response<List<FixtureListViewModel>>> GetAllAsync()
        {
            try
            {
                var res = await _repository.GetAllAsync();
                return Response<List<FixtureListViewModel>>.SuccessData(200, "Demirbaş Listesi Başarıyla Alındı", _mapper.Map<List<FixtureListViewModel>>(res));
            }
            catch (Exception ex)
            {
                return Response<List<FixtureListViewModel>>.FailData(400, "Demirbaş Listesi Başarıyla Alındı", ex.Message, false);
            }
        }
        public async Task<Response> AddAsyc(CreateFixtureViewModel dto)
        {
            try
            {
                await _repository.AddAsync(_mapper.Map<Fixture>(dto));
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Demirbaş Başarıyla Eklendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Demirbaş eklenirken Bir Sorunbla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<UpdateFixtureViewModel>?> GetUpdateDataAsyc(string id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                return entity == null ?
                    Response<UpdateFixtureViewModel>.FailData(404, "Güncellenmek İstenilen Demirbaş Bigilerine Ulaşılamadı", "Güncellenmek İstenilen Demirbaş Bigilerine Ulaşılamadı Id:" + id, true) :
                    Response<UpdateFixtureViewModel>.SuccessData(200, "Güncellenecek Olan Demirbaş Bilgileri Başarıyla Alındı", _mapper.Map<UpdateFixtureViewModel>(entity));
            }
            catch (Exception ex)
            {
                return Response<UpdateFixtureViewModel>.FailData(400, "Güncellenmek İstenilen Demirbaş Bigilerine Ulaşılamadı", ex.Message, false);
            }
        }
        public async Task<Response> Update(UpdateFixtureViewModel dto, string id)
        {
            try
            {
                var updateEntity = _mapper.Map<Fixture>(dto);
                var entity = await _repository.GetByIdAsync(id);

                if (entity == null)
                {
                    Response.Fail(404, "Güncellenmek İstenilen Demirbaş Bigilerine Ulaşılamadı", "Güncellenmek İstenilen Demirbaş Bigilerine Ulaşılamadı Id:" + id, true);
                }

                entity = updateEntity;
                _repository.Update(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Demirbaş Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Demirbaş Güncellenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
    }
}
