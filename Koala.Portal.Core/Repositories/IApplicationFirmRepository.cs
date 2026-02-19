using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Repositories
{
    public interface IApplicationFirmRepository
    {
        Task AddAsync(ApplicationFirms applicationFirm);
        Task<List<ApplicationFirms>> GetApplicationFirms(string applicationId);
        Task<ApplicationFirms> FindApplicationFirm(string Id);
        void Update(ApplicationFirms applicationFirm);
    }
}
