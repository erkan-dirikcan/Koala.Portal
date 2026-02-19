using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Service.Mapping
{
    public class TransactionTypeProfile:Profile
    {
        public TransactionTypeProfile()
        {
            CreateMap<TransactionType, GetTransactionTypeViewModel>().ReverseMap();
            CreateMap<TransactionType, CreateTransactionTypeViewModels>().ReverseMap();
            CreateMap<TransactionType, UpdateTransactionTypeViewModels>().ReverseMap();
        }
    }
}
