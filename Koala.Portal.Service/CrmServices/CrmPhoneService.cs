using System.Linq.Expressions;
using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Service.CrmServices;

public class CrmPhoneService : ICrmPhoneService
{
    private readonly ICrmPhoneRepository _repository;
    private readonly IMapper _mapper;
    public CrmPhoneService(ICrmPhoneRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public Response<List<CrmPhoneNumberInfoViewModel>> Where(Expression<Func<PO_Phone_Number, bool>> predicate)
    {
        var res = _repository.Where(predicate).ToList();
        var retVal = _mapper.Map<List<CrmPhoneNumberInfoViewModel>>(res);
        return Response<List<CrmPhoneNumberInfoViewModel>>.SuccessData(200, "Telefon Listesi BaşarıylaAlındı", retVal);
    }
}