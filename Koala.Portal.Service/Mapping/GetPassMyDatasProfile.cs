using AutoMapper;
using Koala.Portal.Core.GetPassModels;
using Koala.Portal.Core.ViewModels.GetPassViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class GetPassMyDatasProfile:Profile
    {
        public GetPassMyDatasProfile()
        {
            CreateMap<MyDatas, GetPassGetUserInfoViewModels>().ReverseMap();
            CreateMap<MyDatas, GetPassGetUserInfoViewModels>().ReverseMap();
        }
    }
}
