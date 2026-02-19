using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Repository;

namespace Koala.Portal.Service.Services
{
    public class MailTemplateService:BaseService<EmailTemplate>,IMailTemplateService
    {
        private readonly IMailTemplateRepository _mailTemplateRepository;
        public MailTemplateService(IUnitOfWork<AppDbContext> unitOfWork, IBaseRepository<EmailTemplate> baseRepository, IMailTemplateRepository mailTemplateRepository) : base(unitOfWork, baseRepository)
        {
            _mailTemplateRepository = mailTemplateRepository;
        }

        public async Task<Response<EmailTemplate>> GetByNameAsyc(string name)
        {
            var res = await _mailTemplateRepository.GetByNameAsyc(name);
            if (res == null)
            {
                return null;
            }
            return Response<EmailTemplate>.SuccessData(200,"Nesne Bilgisi Başarıyla Alındı",res);
        }
    }
}
