using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class AgendaTypeProfile:Profile
    {
        public AgendaTypeProfile()
        {
            CreateMap<AgendaType, AgendaTypeListViewModel>().ReverseMap();
            CreateMap<AgendaType, CreateAgendaTypeViewModel>().ReverseMap();
            CreateMap<AgendaType, UpdateAgendaTypeViewModel>().ReverseMap();
        }

    }
}
