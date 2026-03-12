using AutoMapper;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Service.Services
{
    public class ProjectLineService : IProjectLineService
    {
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly IProjectLineRepository _repository;
        private readonly IFirmContactService _firmContactService;
        private readonly IMapper _mapper;
        private readonly IProjectLineNoteRepository _noteRepository;
        public ProjectLineService(IUnitOfWork<AppDbContext> unitOfWork, IProjectLineRepository repository, IProjectLineNoteRepository noteRepository, IMapper mapper, IFirmContactService firmContactService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _noteRepository = noteRepository;
            _firmContactService = firmContactService;
        }
        public async Task<Response> AddAsync(AddProjectLineViewModel model)
        {
            try
            {
                var entity = _mapper.Map<ProjectLine>(model);
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Proje Fazı Başarıyla Eklendi.");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Proje Fazı eklenirken bir hata oluştu.", ex.Message, false);
            }
        }
        public async Task<Response<ProjectLineDetailViewModel>> GetProjectLineDetailAsync(string id)
        {
            try
            {
                var res = await _repository.GetByIdAsyc(id);
                if (res == null)
                {
                    return Response<ProjectLineDetailViewModel>.FailData(404, "Proje Faz Bilgilerine Ulaşılamadı", $"{id} kimlik bilgisine sahip faz bilgilerine ulaşılamadı.", true);
                }
                var retVal = _mapper.Map<ProjectLineDetailViewModel>(res);
                
                // CRM yetkilisini manuel çekiyoruz
                if (!string.IsNullOrEmpty(res.LineFirmOfficialId))
                {
                    var crmContact = await _firmContactService.GetDetailAsync(res.LineFirmOfficialId);
                    if (crmContact?.Data != null)
                    {
                        retVal.LineFirmOffcial = new Koala.Portal.Core.ViewModels.CrmViewModels.CrmFirmContactListViewModel 
                        { 
                            Oid = crmContact.Data.Oid, 
                            FullName = crmContact.Data.FullName 
                        };
                    }
                }

                return Response<ProjectLineDetailViewModel>.SuccessData(200, "", retVal);
            }
            catch (Exception ex)
            {
                return Response<ProjectLineDetailViewModel>.FailData(400, $"{id} kimlik bilgisine sahip fazın bilgileri alınırken bir sorunla karşılaşıldı", ex.Message, false);

            }
        }
        public async Task<Response<List<ProjectLineListViewModel>>> GetProjectLineListAsync(string projectId)
        {
            try
            {
                var res = await _repository.Where(x => x.Status != StatusEnum.Deleted).ToListAsync();
                var retVal = _mapper.Map<List<ProjectLineListViewModel>>(res);

                // Her faz için ilerleme hesapla ve CRM yetkilisini çek
                foreach (var line in retVal)
                {
                    var lineEntity = res.FirstOrDefault(x => x.Id == line.Id);
                    if (lineEntity != null)
                    {
                        if (lineEntity.LineWorks != null)
                        {
                            var works = lineEntity.LineWorks.ToList();
                            line.TotalWorkCount = works.Count;
                            line.CompletedWorkCount = works.Count(x => x.WorkStatus == ProjectLineWorkStatusEnum.Completed);

                            // Tahmini süreleri baz alarak ilerleme hesapla
                            var totalEstimated = works.Where(x => x.EstimatedTime.HasValue).Sum(x => x.EstimatedTime.Value);
                            var completedEstimated = works
                                .Where(x => x.WorkStatus == ProjectLineWorkStatusEnum.Completed && x.EstimatedTime.HasValue)
                                .Sum(x => x.EstimatedTime.Value);

                            if (totalEstimated > 0)
                            {
                                line.ProgressPercentage = (int)Math.Round((double)completedEstimated / totalEstimated * 100);
                            }
                            else if (line.CompletedWorkCount > 0 && line.TotalWorkCount > 0)
                            {
                                // Tahmini süre yoksa iş sayısına göre hesapla
                                line.ProgressPercentage = (int)Math.Round((double)line.CompletedWorkCount / line.TotalWorkCount * 100);
                            }
                            else
                            {
                                line.ProgressPercentage = 0;
                            }

                            // Tamamlanmış fazlarda %100 göster
                            if (line.StateStatus == ProjectLineStatusEnum.Completed)
                            {
                                line.ProgressPercentage = 100;
                            }
                        }

                        // CRM yetkilisi ismini çek
                        if (!string.IsNullOrEmpty(lineEntity.LineFirmOfficialId))
                        {
                            var crmContact = await _firmContactService.GetDetailAsync(lineEntity.LineFirmOfficialId);
                            if (crmContact?.Data != null)
                            {
                                line.LineFirmOfficial = crmContact.Data.FullName;
                            }
                        }
                    }
                }

                return Response<List<ProjectLineListViewModel>>.SuccessData(200, "Proje Fazları Başarıyla Alındı.", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<ProjectLineListViewModel>>.FailData(400, "Proje Fazları Alinırken Bir Sorunla Karşılaşıldı.", ex.Message, false);
            }
        }
        public async Task<Response> UpdateAsync(UpdateProjectLineViewModel model, string id)
        {
            try
            {
                var entity = await _repository.GetByIdAsyc(id);
                if (entity == null)
                {
                    return Response.Fail(404, "Güncellenmek istenilen proje fazının bilgilerine ulaşılamadı", $"{id} Id'li Proje Fazı Bilgilerine Ulaşılamadı", true);
                }

                entity.LineOfficialId = model.LineOfficialId;
                entity.LineFirmOfficialId = model.LineFirmOfficialId;
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.DueDate = model.DueDate;
                entity.Priority = model.Priority;
                entity.RowOrder = model.RowOrder;
                entity.UpdateUser = model.UpdateUser;
                entity.UpdateTime = model.UpdateTime;
                await _unitOfWork.CommitAsync();
                return Response.Success(200, $"{entity.Title} Başlıklı Faz Başarıyla Güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Proje fazı güncellenirken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response<List<ProjectLineNoteViewModel>>> GetProjectLineNotesAsync(string projectLineId)
        {
            try
            {
                var res = _noteRepository.Where(x => x.ProjectLineId == projectLineId).ToList();
                var retVal = _mapper.Map<List<ProjectLineNoteViewModel>>(res);
                return Response<List<ProjectLineNoteViewModel>>.SuccessData(200, "Faz notları başarıyla alındı.", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<ProjectLineNoteViewModel>>.FailData(400, "Faz notları alınırken bir sorunla karşılaşıldı.", ex.Message, false);
            }
        }
        public async Task<Response> UpdateProjectLineNote(UpdateProjectLineNoteViewModel model)
        {
            try
            {
                var entity = await _noteRepository.GetByIdAsyc(model.Id);
                if (entity == null)
                {
                    return Response.Fail(404, "Not bilgileri güncellenirken bir sorunla karşlaşıldı.", "Güncellenmek istenen not bilgilerine ulaşılamadı.", true);
                }
                entity.ProjectLineId = model.ProjectLineId;
                entity.UserId = model.UserId;
                entity.Title = model.Title;
                entity.ReportNote = model.ReportNote;
                entity.Note = model.Note;
                entity.Date = model.Date;
                entity.UpdateUser = model.UpdateUser;
                entity.UpdateTime = DateTime.Now;
                _noteRepository.Update(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Faz Notu başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return Response.Fail(404, "Not bilgileri güncellenirken bir sorunla karşlaşıldı.", ex.Message, false);
            }
        }
        public async Task<Response> AddProjectLineNote(AddProjectLineNoteViewModel model)
        {
            try
            {
                var entity = _mapper.Map<ProjectLineNote>(model);
                await _noteRepository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200,"Faz Notu Başarıyla Eklendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Faza not eklenirken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> DeleteAsync(string id)
        {
            try
            {
                var entity = await _repository.GetByIdAsyc(id);
                if (entity == null)
                {
                    return Response.Fail(404, "Silinecek proje fazı bulunamadı", $"{id} kimlik bilgisine sahip faz bulunamadı.", true);
                }

                entity.Status = StatusEnum.Deleted;
                entity.UpdateTime = DateTime.Now;
                _repository.Update(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Proje Fazı Başarıyla Silindi.");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Proje fazı silinirken bir hata oluştu.", ex.Message, false);
            }
        }

        public async Task<Response> ChangeStateStatusAsync(ProjectLineChangeStateStatusViewModel model)
        {
            try
            {
                var entity = await _repository.GetByIdAsyc(model.Id);
                if (entity == null)
                {
                    return Response.Fail(404, "Faz bulunamadı", $"{model.Id} kimlik bilgisine sahip faz bulunamadı.", true);
                }

                // Durum değişikliğine göre tarihleri ayarla
                if (model.Status == ProjectLineStatusEnum.InProgress && entity.StateStatus == ProjectLineStatusEnum.NotStarted)
                {
                    // Faza başlanıyorsa başlangıç tarihini set et
                    entity.StartDate = DateTime.Now;
                }
                else if (model.Status == ProjectLineStatusEnum.Completed)
                {
                    // Faz tamamlanıyorsa bitiş tarihini set et
                    entity.EndDate = DateTime.Now;
                }

                entity.StateStatus = model.Status;
                entity.CancelDescription = model.CancelDescription;
                entity.UpdateTime = DateTime.Now;
                _repository.Update(entity);
                await _unitOfWork.CommitAsync();

                string statusText = model.Status switch
                {
                    ProjectLineStatusEnum.NotStarted => "Başlamadı",
                    ProjectLineStatusEnum.InProgress => "Devam Ediyor",
                    ProjectLineStatusEnum.Completed => "Tamamlandı",
                    ProjectLineStatusEnum.Cancellled => "İptal Edildi",
                    _ => "Değiştirildi"
                };

                return Response.Success(200, $"Faz durumu '{statusText}' olarak değiştirildi.");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Faz durumu değiştirilirken bir hata oluştu.", ex.Message, false);
            }
        }

        public async Task<Response> DeleteProjectLineNoteAsync(string id)
        {
            try
            {
                var entity = await _noteRepository.GetByIdAsyc(id);
                if (entity == null)
                {
                    return Response.Fail(404, "Not bulunamadı", $"{id} kimlik bilgisine sahip not bulunamadı.", true);
                }

                _noteRepository.Delete(entity);
                await _unitOfWork.CommitAsync();
                return Response.Success(200, "Not başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Not silinirken bir hata oluştu.", ex.Message, false);
            }
        }

    }
}
