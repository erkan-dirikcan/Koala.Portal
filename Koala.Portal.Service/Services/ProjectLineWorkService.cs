using AutoMapper;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Microsoft.EntityFrameworkCore;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Helpers;

namespace Koala.Portal.Service.Services
{
    public class ProjectLineWorkService(
        IUnitOfWork<AppDbContext> unitOfWork,
        IMapper mapper,
        IProjectLineWorkRepository repository,
        ICrmSupportService supportService,
        IProjectLineRepository lineRepository,
        ICrmSupportRepository supportRepository,
        IFirmContactService firmContactService)
        : IProjectLineWorkService
    {
        public async Task<Response> AddAsync(AddProjectLineWorkViewModel model)
        {
            try
            {
                var line = await lineRepository.GetByIdAsyc(model.LineId);
                var entity = mapper.Map<ProjectLineWork>(model);
                // WorkId'yi metodun başında oluştur
                entity.Id = Tools.CreateGuidStr().ToString();
                entity.UpdateTime=DateTime.Now;
                entity.UpdateUser = model.CreateUserId;
                // WorkPersons listesini temizle ve yeniden oluştur
                entity.WorkPersons.Clear();

                if (model.WorkPersons != null)
                {
                    foreach (var item in model.WorkPersons)
                    {
                        entity.WorkPersons.Add(new ProjectPerson
                        {
                            Id = Tools.CreateGuidStr(),
                            ProjectId = line.ProjectId,
                            ProjectLineId = line.Id,
                            ProjectLineWorkId = entity.Id,
                            UserId = item.UserId
                        });
                    }
                }

                // İş entity'sini önce veritabanına kaydet
                await repository.AddAsync(entity);
                await unitOfWork.CommitAsync();

                // Destek kaydı oluşturma işlemi - İş kaydından sonra yapılmalı
                if (model.CreateSupportTicket && model.ReleatedSupport != null)
                {
                    // DEBUG: Destek kaydı değerlerini logla
                    Console.WriteLine($"[DEBUG] ReleatedSupport.Firm: {model.ReleatedSupport.Firm}");
                    Console.WriteLine($"[DEBUG] ReleatedSupport.Contact: {model.ReleatedSupport.Contact}");
                    Console.WriteLine($"[DEBUG] ReleatedSupport.Department: {model.ReleatedSupport.Department}");
                    Console.WriteLine($"[DEBUG] ReleatedSupport.AssignedTo: {model.ReleatedSupport.AssignedTo}");

                    // ReleatedSupport'ın geçerli veriler içerip içermediğini kontrol et
                    var hasValidSupportData = model.ReleatedSupport.Firm != Guid.Empty
                                           && model.ReleatedSupport.Contact != Guid.Empty
                                           && model.ReleatedSupport.Department != Guid.Empty
                                           && model.ReleatedSupport.AssignedTo != Guid.Empty;

                    if (hasValidSupportData)
                    {
                        var tModel = mapper.Map<MT_Ticket>(model.ReleatedSupport);
                        tModel.Oid = Tools.CreateGuid(); // Oid explicitly generated
                        tModel.SpeCode = "Koala Portal";
                        tModel.TicketId = supportService.GetNextTicketId();
                        tModel.TicketState = new Guid("5D982B4A-4D94-43F2-960F-834743CBE1B0");
                        tModel.ProjectCode = line.Project.ProjectCode;
                        tModel.ProjectLineId = model.LineId;
                        tModel.ProjectLineWorkId = entity.Id;
                        
                        // Default properties required by CRM/XPO
                        tModel._CreatedDateTime = DateTime.Now;
                        tModel._LastModifiedDateTime = DateTime.Now;
                        tModel.OptimisticLockField = 1;

                        await supportRepository.AddAsyc(tModel);
                        await unitOfWork.CommitAsync();

                        // Destek kaydı OID'sini al ve iş entity'sine bağla
                        var latestSupport = await supportRepository
                            .Where(s => s.ProjectLineWorkId == entity.Id)
                            .OrderByDescending(s => s._CreatedDateTime)
                            .FirstOrDefaultAsync();

                        if (latestSupport != null)
                        {
                            entity.ReleatedSupportId = latestSupport.TicketId;
                            entity.ReleatedSupportOid = latestSupport.Oid.ToString();
                            entity.UpdateTime = DateTime.Now;
                            repository.Update(entity);
                            await unitOfWork.CommitAsync();
                        }
                    }
                }

                return Response.Success(200, "Proje Fazına İş Başarıyla Eklendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
        /// <summary>
        /// İşin durumunu değiştirmek için kullanılır.
        /// </summary>
        /// <param name="model">ProjectLineWorkChangeStateViewModel</param>
        /// <returns></returns>
        public async Task<Response> ChangeWorkStateAsync(ProjectLineWorkChangeStateViewModel model)
        {
            try
            {
                var res = await repository.GetByIdAsyc(model.Id);
                if (res == null)
                {
                    return Response.Fail(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", $"{model.Id} kimlik bilgisine sahip  faz işi bulunamadı", true);
                }
                res.WorkStatus = model.WorkStatus;
                res.UpdateUser = model.UpdateUserId;
                res.UpdateTime = DateTime.Now;
                repository.Update(res);
                await unitOfWork.CommitAsync();
                return Response.Success(200, "Proje faz işinin durumu başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
        /// <summary>
        /// işi tamamlamak için kullanılır
        /// </summary>
        /// <param name="model">ProjectLineWorkComplateViewModel</param>
        /// <returns></returns>
        public async Task<Response> ComplateWorkAsync(ProjectLineWorkComplateViewModel model)
        {
            try
            {
                var res = await repository.GetByIdAsyc(model.Id);
                if (res == null)
                {
                    return Response.Fail(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", $"{model.Id} kimlik bilgisine sahip  faz işi bulunamadı", true);
                }
                res.WorkStatus = ProjectLineWorkStatusEnum.Completed;
                res.ReportDescription = model.ReportDescription;
                res.DeliveredPersonOid = model.DeliveredPersonOid;
                res.UpdateUser = model.UpdateUserId;
                res.UpdateTime = DateTime.Now;
                repository.Update(res);
                await unitOfWork.CommitAsync();
                return Response.Success(200, "Proje faz işinin durumu başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
        /// <summary>
        /// İş Detaylarını Almak İçin Kullanılır
        /// </summary>
        /// <param name="id">iş Id Bilgisi</param>
        /// <returns></returns>
        public async Task<Response<ProjectLineWorkDetailViewModel>> GetProjectLineWorkDetailAsync(string id)
        {
            try
            {
                var res = await repository.GetByIdAsyc(id);
                if (res == null)
                {
                    return Response<ProjectLineWorkDetailViewModel>.FailData(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", $"{id} kimlik bilgisine sahip  faz işi bulunamadı", true);
                }
                var retVal = mapper.Map<ProjectLineWorkDetailViewModel>(res);

                // CRM yetkilisini çek
                if (!string.IsNullOrEmpty(res.LineFirmOfficialId))
                {
                    var crmContact = await firmContactService.GetDetailAsync(res.LineFirmOfficialId);
                    if (crmContact?.Data != null)
                    {
                        retVal.LineFirmOfficialName = crmContact.Data.FullName;
                    }
                }
                if (!string.IsNullOrEmpty(res.DeliveredPersonOid))
                {
                    var crmContact = await firmContactService.GetDetailByOidAsync(res.DeliveredPersonOid);
                    if (crmContact?.Data != null)
                    {
                        retVal.DeliveredPersonName = crmContact.Data.FullName;
                    }
                }

                return Response<ProjectLineWorkDetailViewModel>.SuccessData(200, "Faz işi detaylı bilgileri başarıyla alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<ProjectLineWorkDetailViewModel>.FailData(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
        /// <summary>
        /// Faza Ait işlerin Listesini Almak İçin Kullanılır.
        /// </summary>
        /// <param name="projectLineId">Faz Id Bilgisi</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<List<ProjectLineWorkListViewModel>>> GetProjectLineWorkListAsync(string projectLineId)
        {
            try
            {
                var res = await repository.Where(x => x.LineId == projectLineId).ToListAsync();
                var retVal = mapper.Map<List<ProjectLineWorkListViewModel>>(res);

                // CRM bilgilerini doldur
                foreach (var item in retVal)
                {
                    var entity = res.First(x => x.Id == item.Id);
                    if (!string.IsNullOrEmpty(entity.LineFirmOfficialId))
                    {
                        var crmContact = await firmContactService.GetDetailAsync(entity.LineFirmOfficialId);
                        if (crmContact?.Data != null) item.LineFirmOfficial = crmContact.Data.FullName;
                    }
                    if (!string.IsNullOrEmpty(entity.DeliveredPersonOid))
                    {
                        var crmContact = await firmContactService.GetDetailByOidAsync(entity.DeliveredPersonOid);
                        if (crmContact?.Data != null) item.DeliveredPerson = crmContact.Data.FullName;
                    }
                }

                return Response<List<ProjectLineWorkListViewModel>>.SuccessData(200, "Faza Ait İşler Başarıyla Alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<List<ProjectLineWorkListViewModel>>.FailData(400, "Faz işlerinin listesi alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
        public async Task<Response> UpdateAsync(UpdateProjectLineWorkViewModel model)
        {
            try
            {
                var res = await repository.GetByIdAsyc(model.Id);
                if (res == null)
                {
                    return Response.Fail(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", $"{model.Id} kimlik bilgisine sahip  faz işi bulunamadı", true);
                }

                res.LineFirmOfficialId = model.LineFirmOfficialId;
                res.Name = model.Name;
                res.Description = model.Description;
                res.LetTimeDeduct = model.LetTimeDeduct;
                res.Priority = model.Priority;
                res.RowOrder = model.RowOrder;
                res.UpdateUser = model.LastUpdateUserId;

                // WorkPersons'ı güncelle - Her item'ın UserId'sini kullan
                if (model.WorkPersons != null && model.WorkPersons.Any())
                {
                    // Mevcut WorkPersons'ı temizle
                    res.WorkPersons.Clear();

                    foreach (var item in model.WorkPersons)
                    {
                        res.WorkPersons.Add(new ProjectPerson
                        {
                            Id = Tools.CreateGuidStr(),
                            ProjectId = res.Line.ProjectId,
                            ProjectLineId = res.LineId,
                            ProjectLineWorkId = res.Id,
                            UserId = item.UserId // item'dan UserId kullan
                        });
                    }
                }

                await unitOfWork.CommitAsync();
                return Response.Success(200, "Proje fazına ait iş başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }

        public async Task<Response> DeleteAsync(string id)
        {
            try
            {
                var entity = await repository.GetByIdAsyc(id);
                if (entity == null)
                {
                    return Response.Fail(404, "İş bulunamadı", $"{id} kimlik bilgisine sahip iş bulunamadı.", true);
                }

                repository.Delete(entity);
                await unitOfWork.CommitAsync();
                return Response.Success(200, "İş başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "İş silinirken bir hata oluştu.", ex.Message, false);
            }
        }
    }
}
