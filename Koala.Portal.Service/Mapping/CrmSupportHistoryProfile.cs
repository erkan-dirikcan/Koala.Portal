using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class CrmSupportHistoryProfile:Profile
    {
        public CrmSupportHistoryProfile()
        {
            CreateMap<CreateCrmSupportTicketHistoryViewModel, EX_Ticket_History>()
                .ForMember(dest => dest.UserOid, opt => opt.MapFrom(x => new Guid(x.UserOid)))
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(x => new Guid(x.TicketOid)));
        }
    }
}
