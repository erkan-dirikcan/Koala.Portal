using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class AgendaProfile:Profile
    {
        public AgendaProfile()
        {
            CreateMap<Agenda, AgendaListViewModel>().ReverseMap();
            CreateMap<Agenda, CreateAgendaViewModel>().ReverseMap();
            CreateMap<Agenda, AgendaDetailViewModel>().ReverseMap();
            CreateMap<Agenda, AgendaDetailFirmOfficialsViewModel>().ReverseMap();
            CreateMap<Agenda, AgendaDetailUsersViewModel>().ReverseMap();
            CreateMap<Agenda, AgendaDetailFixtureViewModel>().ReverseMap();
            CreateMap<Agenda, UpdateAgendaViewModel>().ReverseMap();
            CreateMap<Agenda, CancelAgendaViewModel>().ReverseMap();
            CreateMap<Agenda, ComplateAgendaViewModel>().ReverseMap();
            CreateMap<Agenda, AgendaChangeDateViewModel>().ReverseMap();

        }
    }
}
