using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Mapping
{
    public class FixtureProfile:Profile
    {
        public FixtureProfile()
        {
            CreateMap<Fixture, FixtureListViewModel>().ReverseMap();
            CreateMap<Fixture, CreateFixtureViewModel>().ReverseMap();
            CreateMap<Fixture, UpdateFixtureViewModel>().ReverseMap();
            CreateMap<Fixture, DetailFixtureViewModel>().ReverseMap();
            CreateMap<Fixture, DeleteFixtureViewModel>().ReverseMap();
            
        }
    }
}
