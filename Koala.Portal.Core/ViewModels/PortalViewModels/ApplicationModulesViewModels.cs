using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class ApplicationModulesListViewModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Desctiption { get; set; }
    }

    public class CreateApplicationModulesViewModel
    {
        public string ApplicationId { get; set; }
        public string? Name { get; set; }
        public string? Desctiption { get; set; }
    }
    public class ApplicationModulesDecryptedViewModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
    }

    public class ApplicationModulesDecrypJsonViewModel
    {
        public string ApplicationId { get; set; }
        public string? Name { get; set; }
        public string? Desctiption { get; set; }
        public string? CryptedText { get; set; }
    }
   
}
