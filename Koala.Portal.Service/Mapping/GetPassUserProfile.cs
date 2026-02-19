using AutoMapper;
using Koala.Portal.Core.GetPassModels;
using Koala.Portal.Core.ViewModels.GetPassViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class GetPassUserProfile:Profile
    {
        public GetPassUserProfile()
        {
            CreateMap<AspNetUsers, GetSummaryUserInfoViewModel>().ReverseMap();
        }
    }
}
