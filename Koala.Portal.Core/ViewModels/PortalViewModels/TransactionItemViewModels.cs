namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class GetTransactionItemViewModel
    {
        public string Id { get; set; }
        public string? TransactionId { get; set; }
        public string? Description { get; set; }
        public bool IsSuccess { get; set; }
    }
    public class AddTransactionItemViewModel
    {
        public string? TransactionId { get; set; }
        public string? Description { get; set; }
        public bool IsSuccess { get; set; }
    }
}
