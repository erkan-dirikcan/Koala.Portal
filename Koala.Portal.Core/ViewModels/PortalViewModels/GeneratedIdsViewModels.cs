using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class GetGeneratedIdsListViewModel
    {
        public string Id { get; set; } = Tools.CreateGuidStr();
        public string ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string Prefix { get; set; }//lgp
        public int StartNumber { get; set; }//0
        public int LastNumber { get; set; }//1
        public int Digit { get; set; }//6
    }
    public class CreateGeneratedIdsViewModel
    {
        public string ModuleId { get; set; }
        public string Prefix { get; set; }//lgp
        public int StartNumber { get; set; }//0
        public int LastNumber { get; set; }//1
        public int Digit { get; set; }//6
    }
    public class UpdateGeneratedIdsViewModel
    {
        public string Id { get; set; } 
        public string ModuleId { get; set; }
        public string Prefix { get; set; }//lgp
        public int StartNumber { get; set; }//0
        public int LastNumber { get; set; }//1
        public int Digit { get; set; }//6
    }

}
