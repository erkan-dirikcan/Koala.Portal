using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, CreateUserViewModel>().ReverseMap();
            CreateMap<AppUser, UpdateUserVievModel>().ReverseMap();
            CreateMap<AppUser, UserListViewModel>().ReverseMap();
            CreateMap<AppUser, LoginViewModel>().ReverseMap();
            CreateMap<AppUser, ResetPasswordViewModel>().ReverseMap();
            CreateMap<AppUser, ForgetPasswordViewModel>().ReverseMap();
            CreateMap<AppUser, UserProfilInfoViewModel>().ReverseMap();
            CreateMap<AppUser, ChangePasswordViewModel>().ReverseMap();
            CreateMap<AppUser, UserInfoViewModel>().ReverseMap();
            

            CreateMap<ST_User, UserSummaryViewModel>().ReverseMap();
            //CreateMap<AppUser, UserDetailViewModel>().ReverseMap();

        }
    }
}
