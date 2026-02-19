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
        ICrmSupportRepository supportRepository)
        : IProjectLineWorkService
    {
        public async Task<Response> AddAsync(AddProjectLineWorkViewModel model)
        {
            try
            {
                var line = await lineRepository.GetByIdAsyc(model.LineId);
                var entity = mapper.Map<ProjectLineWork>(model);
                var tModel = mapper.Map<MT_Ticket>(model.ReleatedSupport);
                tModel.SpeCode = "Koala Portal";
                tModel.TicketId = supportService.GetNextTicketId();
                tModel.TicketState = new Guid("5D982B4A-4D94-43F2-960F-834743CBE1B0");
                tModel.ProjectCode = line.Project.ProjectCode;
                tModel.ProjectLineId = model.LineId;
                tModel.ProjectLineWorkId=entity.Id;
                await supportRepository.AddAsyc(tModel);


                //var supportRes = await _supportService.AddAsyc(model.ReleatedSupport);
                //if (!supportRes.IsSuccess)
                //{
                //    return supportRes;
                //}

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


                await repository.AddAsync(entity);


                //TODO : buraya Personel ve destek kaydı ekleme işlemleri eklenecek
                await unitOfWork.CommitAsync();
                return Response.Success(404, "Proje Fazına İş Başarıyla Eklendi");
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
        public async Task<Response<ProjectLineDetailViewModel>> GetProjectLineWorkDetailAsync(string id)
        {
            try
            {
                var res = await repository.GetByIdAsyc(id);
                if (res == null)
                {
                    return Response<ProjectLineDetailViewModel>.FailData(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", $"{id} kimlik bilgisine sahip  faz işi bulunamadı", true);
                }
                var retVal = mapper.Map<ProjectLineDetailViewModel>(res);
                return Response<ProjectLineDetailViewModel>.SuccessData(200, "Faz işi detaylı bilgileri başarıyla alındı", retVal);
            }
            catch (Exception ex)
            {
                return Response<ProjectLineDetailViewModel>.FailData(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", ex.Message, false);
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

                res.WorkPersons.Clear();
                foreach (var item in model.WorkPersons)
                {
                    res.WorkPersons.Add(new ProjectPerson
                    {
                        Id = Tools.CreateGuidStr(),
                        ProjectId = res.Line.ProjectId,
                        ProjectLineId = res.LineId,
                        ProjectLineWorkId = res.Id,
                        UserId = model.LastUpdateUserId
                    });
                }

                await unitOfWork.CommitAsync();
                return Response.Success(200, "Proje fazına ait iş başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(404, "Faza işine ait detay bilgileri alınırken bir sorunla karşılaşıldı", ex.Message, false);
            }
        }
    }
}
