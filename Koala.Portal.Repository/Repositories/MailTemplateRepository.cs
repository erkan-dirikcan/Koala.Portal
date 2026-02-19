using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories;

public class MailTemplateRepository : BaseRepository<EmailTemplate>, IMailTemplateRepository
{
    public MailTemplateRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<EmailTemplate> GetByNameAsyc(string name)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
        if (entity != null)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
        return entity;
    }
}

