using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class CrmSupportStateProfile:Profile
    {
        public CrmSupportStateProfile()
        {
            CreateMap<CT_Ticket_States, CrmSupportStatesInfoViewModel>()
                .ForMember(dest=>dest.Oid,
                              opts=> opts.MapFrom(x=>x.Oid.ToString()));
        }
    }
}
