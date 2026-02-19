namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class TransactionListViewModel
    {
        public string Id { get; set; }
        public string TransactionNumber { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplated { get; set; } = false;

        public GetTransactionTypeViewModel? TransactionType { get; set; }
        public UserListViewModel? AppUser { get; set; }
        public List<GetTransactionItemViewModel> TransactionItems { get; set; }
    }
    public class AddTransactionViewModel
    {
        public string? TransactionTypeId { get; set; }
        public string? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplated { get; set; } = false;
        public List<AddTransactionItemViewModel> TransactionItems { get; set; }= [];
    }
    public class UpdateTransactionViewModel
    {
        public string Id { get; set; }
        public string? TransactionTypeId { get; set; }
        public string? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplated { get; set; } = false;
        public List<AddTransactionItemViewModel> TransactionItems { get; set; } = [];
    }

}
