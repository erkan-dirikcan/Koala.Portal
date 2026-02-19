using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.ViewModels.CrmViewModels;
namespace Koala.Portal.Service.Mapping
{
    public class CrmCategoryProfile : Profile
    {
        public CrmCategoryProfile()
        {
            CreateMap<CT_Activity_Category, CrmCategoryInfoViewModels>()
                    .ForMember(dest => dest.Oid, opts => opts.MapFrom(x => x.Oid.ToString()));
        }
    }
}
