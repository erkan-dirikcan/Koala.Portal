using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using System.Linq.Expressions;

namespace Koala.Portal.Service.CrmServices
{
    public class CrmCategoryService : ICrmCategoryService
    {
        private readonly ICrmCategoryRepository _repository;
        private readonly IMapper _mapper;

        public CrmCategoryService(ICrmCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Response<List<CrmCategoryInfoViewModels>> Where(Expression<Func<CT_Activity_Category, bool>> predicate)
        {
            var res = _repository.Where(predicate);
            var retVal = _mapper.Map<List<CrmCategoryInfoViewModels>>(res.ToList());
            return Response<List<CrmCategoryInfoViewModels>>.SuccessData(200, "", retVal);
        }
    }
}
