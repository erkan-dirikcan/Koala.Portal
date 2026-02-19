using Koala.Portal.Core.ViewModels.CrmViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class AddApplicationFirmsViewModel
    {
        public string ApplicationId { get; set; }
        public string FirmId { get; set; }
        /// <summary>
        /// Uygualama Son Kullanım Tarihi (Paket Uygulamalar İçin Geçerli)
        /// </summary>
        //public DateTime? ExpDate { get; set; }
    }

    public class UpdateExpDateApplicationFirmsViewModel
    {
        public string Id { get; set; }
        public string ApplicationId { get; set; }
        public string FirmId { get; set; }
        /// <summary>
        /// Uygualama Son Kullanım Tarihi (Paket Uygulamalar İçin Geçerli)
        /// </summary>
        public DateTime? ExpDate { get; set; }
    }
    public class UpdateExpDateApplicationFirmsJsonModel
    {
        public string Id { get; set; }
        public string ApplicationId { get; set; }
        public string FirmId { get; set; }
        /// <summary>
        /// Uygualama Son Kullanım Tarihi (Paket Uygulamalar İçin Geçerli)
        /// </summary>
        public string? ExpDate { get; set; }
    }

    public class GetApplicationFirmListViewModel
    {
        public string Id { get; set; }
        /// <summary>
        /// Uygualama Son Kullanım Tarihi (Paket Uygulamalar İçin Geçerli)
        /// </summary>
        public DateTime? ExpDate { get; set; }
        public ApplicationsListViewModel Application { get; set; }
        public CrmFirmListViewModel Firm { get; set; }
    }
}
