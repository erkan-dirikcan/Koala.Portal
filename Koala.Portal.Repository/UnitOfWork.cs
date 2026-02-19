using Koala.Portal.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;
        public UnitOfWork(TContext context)
        {
            _context = context;
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            var x=await _context.SaveChangesAsync();

        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
