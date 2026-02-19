using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IRoleService 
    {
        Task<Response> AddAsync(CreateRoleViewModel model);
        Task<Response> Delete(string id);
        Task<Response<RoleListViewModel>> Update(UpdateRoleViewModel model, string id);
        Response<List<RoleListViewModel>> GetRoleList();
        Task<Response> RemoveClaimToRole(string id);
    }
}
