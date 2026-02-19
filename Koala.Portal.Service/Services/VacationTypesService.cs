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
    public class VacationTypesService : IVacationTypesService
    {
        private readonly IVacationTypesRepository _repository;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IMapper _mapper;
        public VacationTypesService(IUnitOfWork<AppDbContext> unitOfWork, IVacationTypesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<VacationTypesViewModel>> AddAsyc(VacationTypesCreateViewModel dto)
        {
            try
            {
                var model = _mapper.Map<VacationTypes>(dto);
                await _repository.AddAsync(model);
                await _unitOfWork.CommitAsync();
                return Response<VacationTypesViewModel>.SuccessData(200, "İzin Tipi Başarıyla Eklendi", _mapper.Map<VacationTypesViewModel>(model));

            }
            catch (Exception ex)
            {
                return Response<VacationTypesViewModel>.FailData(400, "izin Tipi Eklenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> ChangeStatus(VacationTypesChangeStatusViewModel dto)
        {
            try
            {
                var isExsistEntity = await _repository.GetByIdAsync(dto.LineId);
                if (isExsistEntity == null)
                {
                    return Response.Fail(404, "İzin Tipi Güncellenemedi", "Güncellenmek İstenen İzin Tipi Verilerine Ulaşılamadı.", true);
                }
                isExsistEntity.Status = dto.Status;
                _repository.Update(isExsistEntity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "İzin Tipi Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "İzin Tipi Güncellenemedi", ex.Message, false);
            }
        }

        public async Task<Response<IEnumerable<VacationTypesViewModel>>> GetAllAsync()
        {
            try
            {
                var res = await _repository.GetAllAsync();
                var retVal = _mapper.Map<IEnumerable<VacationTypesViewModel>>(res);
                return Response<IEnumerable<VacationTypesViewModel>>.SuccessData(200, "İzin tipi listesi başarıyla alındı.", retVal);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<VacationTypesViewModel>>.FailData(400, "İzin Tipi Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<VacationTypesViewModel>?> GetByIdAsyc(string id)
        {
            try
            {
                var res =await _repository.GetByIdAsync(id);
                var retVal = _mapper.Map<VacationTypesViewModel>(res);
                return Response<VacationTypesViewModel>.SuccessData(200, "", retVal);
            }
            catch (Exception ex)
            {
                return Response<VacationTypesViewModel>.FailData(400, "İzin Tipi Bilgisi Alınırken Bir Sorunla Karşıldı", ex.Message, false);
            }
        }

        public async Task<Response> UpdateAsyc(VacationTypesViewModel dto, string id)
        {
            try
            {
                var isExsistEntity = await _repository.GetByIdAsync(id);
                if (isExsistEntity == null)
                {
                    return Response.Fail(404, "İzin Tipi Güncellenemedi", "Güncellenmek İstenen İzin Tipi Verilerine Ulaşılamadı.", true);
                }
                isExsistEntity.Name = dto.Name;
                isExsistEntity.Description = dto.Description;

                _repository.Update(isExsistEntity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "İzin Tipi Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "İzin Tipi Güncellenemedi", ex.Message, false);
            }
        }
    }
}
