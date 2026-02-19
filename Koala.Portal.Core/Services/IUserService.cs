using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserInfoViewModel>> GetUserInfoById(string id);
        Task<Response<UserInfoViewModel>> GetUserInfoByEmail(string email);
        Task<Response<UserInfoViewModel>> GetUserInfoByOid(string oid);
        Task<Response<List<UserListViewModel>>> GetUserActiveList();
    }
}
