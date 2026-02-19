using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface ITransactionTypeService
    {
        Task<Response<List<GetTransactionTypeViewModel>>> GetTransactionTypeList();
        Task<Response<GetTransactionTypeViewModel>> GetByIdAsync(string id);
        Task<Response<UpdateTransactionTypeViewModels>> GetUpdateInfoAsync(string id);
        Task<Response> ChangeStatusAsync(TransactionTypeChangeStatusViewModel model);
        Task<Response> AddAsync(CreateTransactionTypeViewModels model);
        Task<Response<GetTransactionTypeViewModel>> UpdateAsync(UpdateTransactionTypeViewModels model, string id);
        Task<Response> Delete(string id);
    }
}
