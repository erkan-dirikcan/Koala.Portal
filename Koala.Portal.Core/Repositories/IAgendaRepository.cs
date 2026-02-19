using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Repositories;

public interface IAgendaRepository
{
    Task<List<Agenda>> GetAll();
    Task<List<Agenda>> GetUserAgenda(string userId);
}