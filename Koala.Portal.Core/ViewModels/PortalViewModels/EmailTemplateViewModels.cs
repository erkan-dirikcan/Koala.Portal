using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class CreateEmailTemplateViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
    public class UpdateEmailTemplateViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
    public class EmailTemplateListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
    }
    public class EmailTemplateDetailViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public StatusEnum Status { get; set; }
    }

    public class ChangeStatusEmailTemplateViewModel
    {
        public string Id { get; set; }
        public StatusEnum Status { get; set; }
    }
}
