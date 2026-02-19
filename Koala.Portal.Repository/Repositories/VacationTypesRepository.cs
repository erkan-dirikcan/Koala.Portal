using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;

namespace Koala.Portal.Repository.Repositories
{
    public class VacationTypesRepository : BaseRepository<VacationTypes>, IVacationTypesRepository
    {
        public VacationTypesRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
