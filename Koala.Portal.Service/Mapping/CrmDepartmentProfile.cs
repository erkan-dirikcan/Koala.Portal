using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class CrmDepartmentProfile : Profile
    {
        public CrmDepartmentProfile()
        {
            CreateMap<CT_User_Departments, CrmDepartmentInfoViewModel>()
                .ForMember(dest => dest.Oid, opts => opts.MapFrom(x => x.Oid.ToString()));

        }
    }
}
