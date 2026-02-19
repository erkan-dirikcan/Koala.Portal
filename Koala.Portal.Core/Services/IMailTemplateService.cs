using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Services;

public interface IMailTemplateService:IBaseService<EmailTemplate>
{
    Task<Response<EmailTemplate>> GetByNameAsyc(string name);
}