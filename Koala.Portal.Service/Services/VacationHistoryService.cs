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
    public class VacationHistoryService : IVacationHistoryService
    {
        private readonly IVacationHistoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;

        public VacationHistoryService(IVacationHistoryRepository repository, IMapper mapper, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response> AddVacationHistoryAsync(AddVacationHistoryViewModel model)
        {
            try
            {
                await _repository.AddVacationHistoryAsync(_mapper.Map<VacationHistory>(model));
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "İzin haraket Kaydı Başarıyla Eklendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "izin Haraketi Ekenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
    }
}
