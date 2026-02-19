using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.GetPassViewModels;
using System.Numerics;

namespace Koala.Portal.Core.GetPassServices
{
    public interface IMyDataService
    {
        Task<Response<List<GetPassGetUserInfoViewModels>>> GetMydataAsync(string UserId, BigInteger sKey);
        Task<Response<GetPassGetLineInfoViewModel>> GetPassGetLineInfoAsync(string lineId, BigInteger sKey);
    }
}
