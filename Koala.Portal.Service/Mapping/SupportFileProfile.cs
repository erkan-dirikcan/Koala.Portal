using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class SupportFileProfile:Profile
    {
        public SupportFileProfile()
        {
            CreateMap<SupportFile, GetSupportFileViewModel>().ReverseMap();
        }
    }
}
