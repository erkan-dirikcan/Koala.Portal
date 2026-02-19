using Koala.Portal.Core.GetPassModels;
using Koala.Portal.Core.GetPassRepositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.GetPassRepositories
{
    public class MyDataRepository : IMyDataRepository
    {
        private readonly SistemCryptorContext _context;

        public MyDataRepository(SistemCryptorContext context)
        {
            _context = context;
        }

        public async Task<List<MyDatas>> GetMydataAsync(string UserId)
        {
            var retVal=await _context.MyDatas.Include(x=>x.ServerType).Where(x=>x.ReleatedUserId== UserId).ToListAsync();
            return retVal;
        }

        public  async Task<MyDatas> GetPassGetLineInfoAsync(string dataId)
        {
            var retVal = await _context.MyDatas.FirstOrDefaultAsync(x => x.Id == dataId);
            return retVal;
        }
    }
}
