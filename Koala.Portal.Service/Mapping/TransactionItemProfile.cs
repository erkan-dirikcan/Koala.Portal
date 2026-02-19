using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping;

public class TransactionItemProfile:Profile
{
    public TransactionItemProfile()
    {
        CreateMap<TransactionItem, GetTransactionItemViewModel>().ReverseMap();
        CreateMap<TransactionItem, AddTransactionItemViewModel>().ReverseMap();
    }
}