using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Repositories;

public interface ISupportFileRepository
{
    Task<SupportFile> GetBySupportIdAsyc(string ticketId);
    Task<SupportFile> GetByIdAsyc(string fileId);
} 