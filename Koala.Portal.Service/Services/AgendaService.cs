using AutoMapper;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;

namespace Koala.Portal.Service.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;

        public AgendaService(IMapper mapper, IAgendaRepository repository, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<AgendaDetailViewModel>> GetAll()
        {
            var data = await _repository.GetAll();
            var retVal = _mapper.Map<List<AgendaDetailViewModel>>(data);
           
            return retVal;
        }

        public async Task<List<AgendaDetailViewModel>> GetUserAgenda(string userId)
        {
            var data = await _repository.GetUserAgenda(userId);
            var retVal = new List<AgendaDetailViewModel>();

            return retVal;
        }
    }
}
