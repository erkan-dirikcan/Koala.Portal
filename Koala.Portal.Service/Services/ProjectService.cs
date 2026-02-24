using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Koala.Portal.Core.CrmServices;

namespace Koala.Portal.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IProjectRepository _repository;
        private readonly IProjectFileRepository _fileRepository;
        private readonly IMapper _mapper;
        private readonly IGeneratedIdsService _generatedIdsService;
        private readonly IEmailService _mailService;
        private readonly IUserService _userService;
        private readonly IFirmService _firmService;
        private readonly ICrmFirmService _crmFirmService;
        private readonly IFirmContactService _firmContactService;


        public ProjectService(IUnitOfWork<AppDbContext> unitOfWork, IProjectRepository repository, IMapper mapper, IProjectFileRepository fileRepository, IGeneratedIdsService generatedIdsService, IEmailService mailService, IUserService userService, IFirmService firmService, ICrmFirmService crmFirmService, IFirmContactService firmContactService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _fileRepository = fileRepository;
            _generatedIdsService = generatedIdsService;
            _mailService = mailService;
            _userService = userService;
            _firmService = firmService;
            _crmFirmService = crmFirmService;
            _firmContactService = firmContactService;
        }
        /// <summary>
        /// Yeni bir proje oluşturur
        /// </summary>
        /// <param name="model">AddProjectViewModel</param>
        /// <returns>Response string tipinden Proje Id bilgisi döndürülür</returns>
        public async Task<Response<string>> AddAsync(AddProjectViewModel model)
        {
            try
            {
                var entity = _mapper.Map<Project>(model);
                var nextId = await _generatedIdsService.GetNextNumber("069f9c87-dbb5-11ee-a5b1-704d7b71982b");
                entity.ProjectCode = nextId.Data;
                entity.UpdateUser = model.CreateUser;
                entity.UpdateTime = DateTime.Now;
                await _repository.AddAsync(entity);
                var createUser = await _userService.GetUserInfoById(entity.CreateUser);

                //Local veri tabanı Firma Bilgisi(Oid Bilgisini Almak İçin Gerekli)
                var firm = await _firmService.GetFirmByIdAsync(entity.FirmId);
                var crmFirm = _crmFirmService.GetFirmInfo(firm.Data.Oid);

                var crmContactOid = await _firmContactService.GetOidAsync(model.FirmPersonId);
                var firmPerson = crmFirm.Data.Contacts.FirstOrDefault(x =>
                    string.Equals(x.Oid, crmContactOid.Data, StringComparison.OrdinalIgnoreCase));

                var projectManager = await _userService.GetUserInfoById(entity.ProjectManagerId);
                await _unitOfWork.CommitAsync();
                ////Local veri tabanı contact Bilgisi(Oid Bilgisini Almak İçin Gerekli)
                var mailModel = new ProjectCustomEmailDto();
                mailModel.CreateUser = createUser.Data.Fullname;
                mailModel.CreateDate = entity.CreateTime.ToString("dd-MM-yyyy");
                mailModel.ProjectId = entity.Id;
                mailModel.ProjectCode = entity.ProjectCode;
                mailModel.DueDate = entity.DueDate?.ToString("dd-MM-yyyy");
                mailModel.ProjectName = entity.ProjectName;
                mailModel.Email = projectManager.Data.Email;
                mailModel.FirmName = $"({crmFirm.Data.Title}) - {crmFirm.Data.Title}";
                mailModel.FirmProjectManager = projectManager.Data.Fullname;
                mailModel.ProjectManagerPhones = !string.IsNullOrEmpty(firmPerson.Phones.FirstOrDefault()?.ToString()) ? firmPerson.Phones.FirstOrDefault()?.ToString() : "Crm telefon bilgisi kaydedilmemiş";
                mailModel.Name = projectManager.Data.Name;
                mailModel.Lastname =  projectManager.Data.Lastname;
                mailModel.ProjectDescription = entity.Description;
                mailModel.ProjectManagerEmail = projectManager.Data.Email;
                var mailRes = await _mailService.SendProjectEmailAsync(mailModel);
                
                
                return Response<string>.SuccessData(200, "Proje Başarıyla Oluşturuldu.",entity.Id);
            }
            catch (Exception ex)
            {
                return Response<string>.FailData(400, "Proje oluşturulurken bir hata oluştu.", ex.Message, false);
            }
        }
        public async Task<Response<List<ProjectListViewModel>>> GetFirmProjectListAsync(string firmId)
        {
            try
            {
                var res = await _repository.Where(x => x.FirmId == firmId && x.Status != StatusEnum.Deleted).ToListAsync();
                var retVal = _mapper.Map<List<ProjectListViewModel>>(res);
                return Response<List<ProjectListViewModel>>.SuccessData(200, "Firma Projeleri Başarıyla Alındı.", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<ProjectListViewModel>>.FailData(400, "Firma Projeleri Alinırken Bir Sorunla Karşılaşıldı.", ex.Message, false);
            }
        }
        public async Task<Response<List<ProjectListViewModel>>> GetFirmProjectListByFirmOidAsync(string firmOid)
        {
            try
            {
                var res = await _repository.Where(x => x.Firm.Oid == firmOid).ToListAsync();
                var retVal = _mapper.Map<List<ProjectListViewModel>>(res);
                return Response<List<ProjectListViewModel>>.SuccessData(200, "Firma Projeleri Başarıyla Alındı.", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<ProjectListViewModel>>.FailData(400, "Firma Projeleri Alinırken Bir Sorunla Karşılaşıldı.", ex.Message, false);
            }
        }
        public async Task<Response<ProjectDetailViewModel>> GetProjectByCodeAsync(string code)
        {
            try
            {
                var res = await _repository.GetByCodeAsyc(code);
                if (res == null)
                {
                    return Response<ProjectDetailViewModel>.FailData(404, "Proje Bilgilerine Ulaşılamadı", $"{code} kodlu projenin bilgilerine ulaşılamadı.", true);
                }
                var retVal = _mapper.Map<ProjectDetailViewModel>(res);
                return Response<ProjectDetailViewModel>.SuccessData(200, "", retVal);
            }
            catch (Exception ex)
            {
                return Response<ProjectDetailViewModel>.FailData(400, "Proje Bilgisi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<ProjectDetailViewModel>> GetProjectByIdAsync(string id)
        {
            try
            {
                var res = await _repository
                    .Where(x => x.Id == id)
                    .Include(x => x.ProjectLines)
                        .ThenInclude(x => x.LineOffcial)
                    .Include(x => x.ProjectLines)
                        .ThenInclude(x => x.LineFirmOffcial)
                    .Include(x => x.Firm)
                    .FirstOrDefaultAsync();

                if (res == null)
                {
                    return Response<ProjectDetailViewModel>.FailData(404, "Proje Bilgilerine Ulaşılamadı", $"{id} kimlik bilgisine sahip projenin bilgilerine ulaşılamadı.", true);
                }
                var retVal = _mapper.Map<ProjectDetailViewModel>(res);
                return Response<ProjectDetailViewModel>.SuccessData(200, "", retVal);
            }
            catch (Exception ex)
            {
                return Response<ProjectDetailViewModel>.FailData(400, $"{id} kimlik bilgisine sahip projenin bilgileri alınırken bir sorunla karşılaşıldı", ex.Message, false);

            }
        }
        public async Task<Response<List<ProjectListViewModel>>> GetProjectListAsync()
        {
            try
            {
                var res = await _repository.Where(x => x.Status == StatusEnum.Active
                && x.ProjectStatus != ProjectStatusEnum.Finished
                && x.ProjectStatus != ProjectStatusEnum.Failed
                && x.ProjectStatus != ProjectStatusEnum.Canceled).ToListAsync();
                var retVal = _mapper.Map<List<ProjectListViewModel>>(res);
                return Response<List<ProjectListViewModel>>.SuccessData(200, "Firma Projeleri Başarıyla Alındı.", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<ProjectListViewModel>>.FailData(400, "Firma Projeleri Alinırken Bir Sorunla Karşılaşıldı.", ex.Message, false);
            }
        }
        public async Task<Response<ProjectDetailViewModel>> UpdateAsync(UpdateProjectViewModel model, string id)
        {
            try
            {
                var entity = await _repository.GetByIdAsyc(id);
                if (entity == null)
                {
                    return Response<ProjectDetailViewModel>.FailData(404, "Güncellenmek istenilen proje bilgilerine ulaşılamadı", $"{id} kimlik bilgisine sahip proje veri tabanında bulunamadı.", true);
                }

                entity.ProjectName = model.ProjectName;
                entity.Description = model.Description;
                entity.ProjectManagerId = model.ProjectManagerId;
                entity.FirmId = model.FirmId;
                entity.FirmPersonId = model.FirmPersonId;
                if (model.ServiceHour != null)
                {
                    entity.ServiceHour = model.ServiceHour;
                }
                if (model.DueDate != null)
                {
                    var duoDate = DateTime.ParseExact(model.DueDate!, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    entity.DueDate = duoDate;
                }
                entity.UpdateUser = "";
                entity.UpdateTime = DateTime.Now;
                _repository.Update(entity);
                await _unitOfWork.CommitAsync();
                return await GetProjectByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Response<ProjectDetailViewModel>.FailData(400, "Proje güncellenirken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response> DeleteAsync(string id)
        {
            try
            {
                var project = await _repository.GetByIdAsyc(id);
                if (project != null)
                {
                    _repository.Delete(project);
                    await _unitOfWork.CommitAsync();
                }
                return Response.Success(200, "Proje Başarıyla Silindi.");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Proje Silinirken Bir Hata Oluştu.", ex.Message, false);
            }
        }
        public async Task<Response> AddFileToProject(AddProjectFilesViewModel model)
        {
            try
            {
                _fileRepository.AddFile(_mapper.Map<ProjectFiles>(model));
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Proje Dosyası Başarıyla Eklendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Proje Dosyası Eklenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<ProjectFilesListViewModel>> GetProjectFile(string fileId)
        {
            try
            {
                var res = await _fileRepository.GetFile(fileId);
                if (res != null)
                {
                    return Response<ProjectFilesListViewModel>.FailData(404, "Proje Dosyası Bilgileri alınırken Bir Sorunla Karşılaşıldı", "Proje Dosyası Bilgilerine Ulaşılamadı", true);
                }
                var retVal = _mapper.Map<ProjectFilesListViewModel>(res);

                return Response<ProjectFilesListViewModel>.SuccessData(200, "Dosya Bilgisi Başarıyla Alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<ProjectFilesListViewModel>.FailData(400, "Proje Dosyası Bilgileri Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response> DeleteFileToProject(string fileId)
        {
            try
            {
                var res = await _fileRepository.GetFile(fileId);
                if (res != null)
                {
                    return Response.Fail(404, "Proje Dosyası Bilgileri alınırken Bir Sorunla Karşılaşıldı", "Proje Dosyası Bilgilerine Ulaşılamadı", true);
                }
                _fileRepository.DeleteFile(res);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Proje dosyası başarıyla silindi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Proje Dosyası Silinirken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<List<ProjectFilesListViewModel>>> GetAllProjectFiles(string projectId)
        {
            try
            {
                var res = await _fileRepository.GetAllFiles(projectId);
                var retVal = _mapper.Map<List<ProjectFilesListViewModel>>(res.ToList());
                return Response<List<ProjectFilesListViewModel>>.SuccessData(200, "Proje Dosyaları Başarıyla Alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<ProjectFilesListViewModel>>.FailData(200, "Proje Dosyaları Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false);
            }
        }

    }
}
