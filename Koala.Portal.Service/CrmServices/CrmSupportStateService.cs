using System.Linq.Expressions;
using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Service.CrmServices
{
    public class CrmSupportStateService : ICrmSupportStateService
    {
        private readonly ICrmSupportStatesRepository _repository;
        private readonly IMapper _mapper;
        public CrmSupportStateService(ICrmSupportStatesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<Response<List<CrmSupportStatesInfoViewModel>>> WhereAsync(Expression<Func<CT_Ticket_States, bool>> predicate)
        {
            try
            {
                var retVal = await _repository.WhereAsync(predicate);
                return Response<List<CrmSupportStatesInfoViewModel>>.SuccessData(200, "", _mapper.Map<List<CrmSupportStatesInfoViewModel>>(await retVal.ToListAsync()));
            }
            catch (Exception ex)
            {
                return Response<List<CrmSupportStatesInfoViewModel>>.FailData(400, "Destek durum listesi alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response<List<CrmSupportStatesInfoViewModel>>> GetAllAsync()
        {

            try
            {
                var retVal = await _repository.GetAllAsync();
                return _mapper.Map<Response<List<CrmSupportStatesInfoViewModel>>>(retVal);
            }
            catch (Exception ex)
            {
                return Response<List<CrmSupportStatesInfoViewModel>>.FailData(400, "Destek durum listesi alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
    }
}
