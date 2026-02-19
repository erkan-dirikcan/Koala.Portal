using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Repositories;

public interface IMailTemplateRepository:IBaseRepository<EmailTemplate>
{
    Task<EmailTemplate> GetByNameAsyc(string name);
}