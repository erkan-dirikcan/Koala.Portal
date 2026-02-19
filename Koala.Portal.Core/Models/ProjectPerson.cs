using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.Models
{
    public class ProjectPerson
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        /// <summary>
        /// İlişkili Kullanıcı.
        /// Bu alan Sadece İşler İle User Tablosuna İlişkilendirilebilir...!
        /// Proje ve faz ilişkisi istenilir ise Onlar için ayrı kullanıcı bağlantısı açmak gerekir.
        /// </summary>
        public string? UserId { get; set; }
        public string? ProjectId { get; set; }
        public string? ProjectLineId { get; set; }
        public string? ProjectLineWorkId { get; set; }

        public virtual AppUser? User { get; set; }
        public virtual ProjectLineWork? ProjectLineWork { get; set; }


    }
}
