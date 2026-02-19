using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Newtonsoft.Json;

namespace Koala.Portal.Service.Services
{
    public class VacationRequestService : IVacationRequestService
    {

        private readonly IVacationRequestRepository _repository;
        private readonly IVacationHistoryRepository _historyRepository;
        private readonly IGeneratedIdsService _generatedIdsService;
        
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;

        public VacationRequestService(IVacationRequestRepository repository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork, IVacationHistoryRepository historyRepository, IUserRepository userRepository, IGeneratedIdsService generatedIdsService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _historyRepository = historyRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _generatedIdsService = generatedIdsService;
        }

        public async Task<Response> CancelAsyc(VacationRequestCancelViewModel model, string userId)
        {
            var request = await _repository.GetByIdAsyc(model.Id);
            if (request == null)
            {
                return Response.Fail(404, "iptal edilmek istenilen talep bilgilerine ulaşılamadı", $"{model.Id} kimlik bilgisine sahip izin talebi bilgilerine ulaşılamadı", true);
            }
            request.CancelDescription = model.CancelDescription;
            request.UserId = userId;
            request.Status = VacationStatus.Canceled;
            request.UpdateTime = DateTime.Now;
            request.UpdateUser = userId;
            var user = await _userRepository.GetUserInfoById(userId);
            var historyModel = new VacationHistory
            {
                CreateTime = DateTime.Now,
                CreateUser = userId,
                Description = $"{user.Name} {user.Lastname} isinli kullanıcı tarafından yeni bir izin talebi oluşturuldu. Talep Kodu : {request.ReqNumber}",
                IsAdded = false,
                ReleatedUserId = request.UserId,
                UpdateTime = DateTime.Now,
                VacationId = request.Id
            };
            await _historyRepository.AddVacationHistoryAsync(historyModel);
            await _unitOfWork.CommitAsync();
            return Response.Success(200, $"{request.ReqNumber} Numaralı izin talebi için revizyon talebi bvaşarıyla oluşturuldu");
        }

        public async Task<Response> CreateRequestAsyc(VacationRequestCreateViewModel model, string userId)
        {
            try
            {

                var addModel = _mapper.Map<VacationRequest>(model);
                var nextId=await _generatedIdsService.GetNextNumber("VAC");
                addModel.CreateTime = DateTime.Now;
                addModel.CreateUser = userId;
                addModel.ReqNumber = nextId.Data;
                addModel.Status=VacationStatus.WaitingForApproval;
                await _repository.AddAsyc(addModel);               
                var user = await _userRepository.GetUserInfoById(userId);
                var historyModel = new VacationHistory
                {
                    CreateTime = DateTime.Now,
                    CreateUser = userId,
                    Description = $"{user.Name} {user.Lastname} isinli kullanıcı tarafından yeni bir izin talebi oluşturuldu. Talep Kodu : {model.ReqNumber}",
                    IsAdded = false,
                    ReleatedUserId = model.UserId,
                    UpdateTime = DateTime.Now,
                    VacationId = addModel.Id
                };

                await _historyRepository.AddVacationHistoryAsync(historyModel);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "İzin Talebi Başarıyla Eklendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400,"İzin talebi oluşturulurken bir sorunla karşılaşıldı",ex.Message,false);
            }

        }

        public async Task<Response<VacationRequestDetailViewModel?>> GetByIdAsyc(string id)
        {
            var res = await _repository.GetByIdAsyc(id);
            return Response<VacationRequestDetailViewModel>.SuccessData(200, "İzin Bilgisi Başarıyla Alındı", _mapper.Map<VacationRequestDetailViewModel>(res));
        }

        public async Task<Response<List<VacationRequestListViewModel>>> GetVacationRequests()
        {
            var res = await _repository.GetAllAsync();
            return Response<List<VacationRequestListViewModel>>.SuccessData(200, "İzin Listesi Başarıyla Alındı", _mapper.Map<List<VacationRequestListViewModel>>(res));

        }

        public async Task<Response> RevisionRequestAsyc(VacationRequestRevisionRequestViewModel model, string userId)
        {
            try
            {
                var request = await _repository.GetByIdAsyc(model.Id);
                if (request == null)
                {
                    return Response.Fail(404, "Revizyon istenilen talep bilgilerine ulaşılamadı", $"{model.Id} kimlik bilgisine sahip izin talebi bilgilerine ulaşılamadı", true);
                }
                request.RevisionDescription = model.RevisionDescription;
                request.UserId = userId;
                request.Status = VacationStatus.WaitingForRevision;
                request.UpdateTime = DateTime.Now;
                request.UpdateUser = userId;
                var user = await _userRepository.GetUserInfoById(userId);
                var historyModel = new VacationHistory
                {
                    CreateTime = DateTime.Now,
                    CreateUser = userId,
                    Description = $"{user.Name} {user.Lastname} isinli kullanıcı tarafından yeni bir izin talebi oluşturuldu. Talep Kodu : {request.ReqNumber}",
                    IsAdded = false,
                    ReleatedUserId = request.UserId,
                    UpdateTime = DateTime.Now,
                    VacationId = request.Id
                };
                await _historyRepository.AddVacationHistoryAsync(historyModel);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, $"{request.ReqNumber} Numaralı izin talebi için revizyon talebi bvaşarıyla oluşturuldu");
            }
            catch (Exception ex)
            {
                return Response.Fail(404, "Revizyon istenilen talep bilgilerine ulaşılamadı", ex.Message, false);
            }
        }

        public async Task<Response> UpdateRequestAsyc(VacationRequestRevisionViewModel model, string userId)
        {
            var request = await _repository.GetByIdAsyc(model.Id);
            var modelOld= JsonConvert.SerializeObject(request);
            if (request == null)
            {
                return Response.Fail(404, "Güncellenmek istenilen talep bilgilerine ulaşılamadı", $"{model.Id} kimlik bilgisine sahip izin talebi bilgilerine ulaşılamadı", true);
            }
            request.VacationTypeId=model.VacationTypeId;
            request.Subject = model.Subject;
            request.Description = model.Description;
            request.StartDate = model.StartDate;
            request.EndDate = model.EndDate;
            request.UpdateTime = DateTime.Now;
            request.UpdateUser = userId;
            request.DropFromAnnualVaccation = model.DropFromAnnualVaccation;

            var user = await _userRepository.GetUserInfoById(userId);
            var historyModel = new VacationHistory
            {
                CreateTime = DateTime.Now,
                CreateUser = userId,
                Description = $"{user.Name} {user.Lastname} isinli kullanıcı tarafından güncelleme işlemi gerçekleştirildi. Talep Kodu : {request.ReqNumber} - Eski Talep : {modelOld} - Güncel Talep : {JsonConvert.SerializeObject(request)}",
                IsAdded = false,
                ReleatedUserId = request.UserId,
                UpdateTime = DateTime.Now,
                VacationId = request.Id
            };
            await _historyRepository.AddVacationHistoryAsync(historyModel);
            await _unitOfWork.CommitAsync();
            return Response.Success(200, $"{request.ReqNumber} Numaralı izin talebi  talebi başarıyla güncellendi");
        }
    }
}
