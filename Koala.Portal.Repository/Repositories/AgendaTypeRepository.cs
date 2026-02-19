using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;

namespace Koala.Portal.Repository.Repositories;

public class AgendaTypeRepository:BaseRepository<AgendaType>,IAgendaTypeRepository
{
    public AgendaTypeRepository(AppDbContext context) : base(context)
    {
    }
}