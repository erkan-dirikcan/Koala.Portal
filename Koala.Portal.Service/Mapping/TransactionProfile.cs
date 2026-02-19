using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping;

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<Transaction, TransactionListViewModel>().ReverseMap();
        CreateMap<Transaction, AddTransactionViewModel>().ReverseMap();
    }
}