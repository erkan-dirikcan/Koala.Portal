using Koala.Portal.Core.GetPassModels;

namespace Koala.Portal.Core.GetPassRepositories
{
    public interface IMyDataRepository
    {
        Task<List<MyDatas>> GetMydataAsync(string UserId);
        Task<MyDatas> GetPassGetLineInfoAsync(string dataId);
    }
}
