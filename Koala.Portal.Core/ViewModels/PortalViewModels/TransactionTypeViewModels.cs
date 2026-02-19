using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class GetTransactionTypeViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Icon { get; set; }
        public string? ColorClass { get; set; }

        public StatusEnum Status { get; set; }
    }
    public class CreateTransactionTypeViewModels
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Icon { get; set; }
        public string? ColorClass { get; set; }
    }
    public class UpdateTransactionTypeViewModels
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Icon { get; set; }
        public string? ColorClass { get; set; }
    }
    public class TransactionTypeChangeStatusViewModel
    {
        public string Id { get; set; }
        public StatusEnum Status { get; set; }
    }


}
