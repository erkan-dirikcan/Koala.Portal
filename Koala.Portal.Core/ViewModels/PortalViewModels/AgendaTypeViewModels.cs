using System.ComponentModel.DataAnnotations;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class AgendaTypeListViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Arkaplan Rengi")]
        public string BackColor { get; set; }
        [Display(Name = "Yazı Rengi")]
        public string FontColor { get; set; }
        [Display(Name = "Çizgi Rengi")]
        public string BorderColor { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
    }
    public class CreateAgendaTypeViewModel
    {
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Arkaplan Rengi")]
        public string BackColor { get; set; }
        [Display(Name = "Yazı Rengi")]
        public string FontColor { get; set; }
        [Display(Name = "Çizgi Rengi")]
        public string BorderColor { get; set; }
    }
    public class UpdateAgendaTypeViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Arkaplan Rengi")]
        public string BackColor { get; set; }
        [Display(Name = "Yazı Rengi")]
        public string FontColor { get; set; }
        [Display(Name = "Çizgi Rengi")]
        public string BorderColor { get; set; }
    }
}
