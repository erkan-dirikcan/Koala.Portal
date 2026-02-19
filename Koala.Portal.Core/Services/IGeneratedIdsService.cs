using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IGeneratedIdsService
    {
        Task<Response<List<GetGeneratedIdsListViewModel>>> GetGeneratedIdsList();
        Task<Response<GetGeneratedIdsListViewModel>> GetByIdAsync(string id);
        Task<Response<UpdateGeneratedIdsViewModel>> GetUpdateInfoAsync(string id);
        Task<Response> AddAsync(CreateGeneratedIdsViewModel model);
        Task<Response<GetGeneratedIdsListViewModel>> UpdateAsync(UpdateGeneratedIdsViewModel model, string id);
        Task<Response<string>> GetNextNumber(string id);
    }
}
