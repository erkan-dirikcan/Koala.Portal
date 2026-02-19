using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;

namespace Koala.Portal.Repository.Repositories
{
    public class FixtureRepository:BaseRepository<Fixture>,IFixtureRepository
    {
        public FixtureRepository(AppDbContext context) : base(context)
        {
        }
    }
}
