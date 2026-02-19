using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IClaimService
    {
        Task<Response<IEnumerable<ClaimListViewModels>>> GetAllAsync();
        Task<Response<IEnumerable<ClaimListForRoleViewModels>>> GetClaimToRoleList();
        Task<Response<IEnumerable<ClaimListForUserViewModels>>> GetClaimToUserList(List<string> claims);
        Task<Response<UpdateClaimViewModels>> GetUpdateInfoAsync(string id);
        Task<Response<ClaimListForModuleViewModels>> GetByIdAsync(string id);
        Task<Response<IEnumerable<ClaimListForModuleViewModels>>> GetClaimToModuleList(string moduleId);
        Task<Response> AddAsync(CreateClaimViewModels model);
        Task<Response> DeleteAsync(string id);
        Task<Response> UpdateAsync(UpdateClaimViewModels model,string id);
      
    }
}
