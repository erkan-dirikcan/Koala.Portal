using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using System.Linq.Expressions;

namespace Koala.Portal.Service.CrmServices
{
    public class CrmDepartmentService : ICrmDepartmentService
    {
        private readonly ICrmDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public CrmDepartmentService(ICrmDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Response<List<CrmDepartmentInfoViewModel>> Where(Expression<Func<CT_User_Departments, bool>> predicate)
        {
            var res = _repository.Where(predicate);
            var retVal = _mapper.Map<List<CrmDepartmentInfoViewModel>>(res.ToList());
            return Response<List<CrmDepartmentInfoViewModel>>.SuccessData(200, "", retVal);
        }
    }
}
