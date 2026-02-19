namespace Koala.Portal.Core.Models
{
    public class ApplicationUpdate
    {
        public string Id { get; set; }
        public string ApplicationGuid { get; set; }
        public string Version { get; set; }
        public string UpdateDescription { get; set; }
        public string UpdateFiles { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
    }
}
