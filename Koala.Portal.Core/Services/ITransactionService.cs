using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services;

public interface ITransactionService
{
    Task<Response<List<TransactionListViewModel>>> GetTransactionList();
    Task<Response<List<TransactionListViewModel>>> GetModuleTransactionList(string moduleId);
    Task<Response<List<TransactionListViewModel>>> GetUserTransactionList(string userId);
    Task<Response<TransactionListViewModel>> GetByIdAsync(string id);
    Task<Response> AddAsync(AddTransactionViewModel transaction);
    Task<Response> AddItemAsync(AddTransactionItemViewModel model);
}