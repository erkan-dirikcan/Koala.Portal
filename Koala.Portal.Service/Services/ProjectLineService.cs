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
        private readonly IProjectLineNoteRepository _noteRepository;
        private readonly IMapper _mapper;
        public ProjectLineService(IUnitOfWork<AppDbContext> unitOfWork, IProjectLineRepository repository, IProjectLineNoteRepository noteRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _noteRepository = noteRepository;
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
                entity.RowOrdwer = model.RowOrdwer;
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

    }
}
