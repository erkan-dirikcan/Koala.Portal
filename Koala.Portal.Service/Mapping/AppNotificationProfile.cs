using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class AppNotificationProfile : Profile
    {
        public AppNotificationProfile()
        {
            CreateMap<AppNotification, AppNotificationViewModel>()
                .ForMember(dest => dest.TimeAgo, opts => opts.Ignore()); // Calculated in service
        }
    }
}
