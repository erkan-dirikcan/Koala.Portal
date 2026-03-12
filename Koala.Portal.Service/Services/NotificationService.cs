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
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly INotificationRepository _notificationRepository;
        private readonly IProjectService _projectService;
        private readonly IProjectLineService _projectLineService;
        private readonly IProjectLineWorkService _workService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public NotificationService(
            IUnitOfWork<AppDbContext> unitOfWork,
            INotificationRepository notificationRepository,
            IProjectService projectService,
            IProjectLineService projectLineService,
            IProjectLineWorkService workService,
            IEmailService emailService,
            IUserService userService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _notificationRepository = notificationRepository;
            _projectService = projectService;
            _projectLineService = projectLineService;
            _workService = workService;
            _emailService = emailService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Response> NotifyProjectAssignedAsync(string projectId, string userId)
        {
            try
            {
                var projectResult = await _projectService.GetProjectByIdAsync(projectId);
                if (!projectResult.IsSuccess || projectResult.Data == null)
                {
                    return Response.Fail(404, "Proje bulunamadı", "Proje bilgilerine ulaşılamadı", true);
                }

                var project = projectResult.Data;
                var userResult = await _userService.GetUserInfoById(userId);
                var userName = userResult.IsSuccess ? userResult.Data?.Fullname ?? "Kullanıcı" : "Kullanıcı";

                var title = "Yeni Proje Ataması";
                var message = $"{project.ProjectName} ({project.ProjectCode}) projesi size atandı.";
                var actionUrl = $"/Project/Detail/{projectId}";

                await CreateInAppNotificationAsync(userId, title, message, "ViewProject", projectId, actionUrl);

                // Send email notification
                await SendEmailNotificationAsync(userId, title, message, actionUrl);

                return Response.Success(200, "Bildirim başarıyla gönderildi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Bildirim gönderilemedi", ex.Message, false);
            }
        }

        public async Task<Response> NotifyProjectStatusChangedAsync(string projectId, ProjectStatusEnum newStatus)
        {
            try
            {
                var projectResult = await _projectService.GetProjectByIdAsync(projectId);
                if (!projectResult.IsSuccess || projectResult.Data == null)
                {
                    return Response.Fail(404, "Proje bulunamadı", "Proje bilgilerine ulaşılamadı", true);
                }

                var project = projectResult.Data;
                var statusText = GetProjectStatusText(newStatus);

                // Notify project manager
                if (!string.IsNullOrEmpty(project.ProjectManagerId))
                {
                    var title = "Proje Durumu Değişti";
                    var message = $"{project.ProjectName} projesinin durumu '{statusText}' olarak güncellendi.";
                    var actionUrl = $"/Project/Detail/{projectId}";

                    await CreateInAppNotificationAsync(project.ProjectManagerId, title, message, "ViewProject", projectId, actionUrl);
                }

                return Response.Success(200, "Bildirim başarıyla gönderildi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Bildirim gönderilemedi", ex.Message, false);
            }
        }

        public async Task<Response> NotifyWorkAssignedAsync(string workId, string userId)
        {
            try
            {
                var workResult = await _workService.GetProjectLineWorkDetailAsync(workId);
                if (!workResult.IsSuccess || workResult.Data == null)
                {
                    return Response.Fail(404, "İş bulunamadı", "İş bilgilerine ulaşılamadı", true);
                }

                var workDetail = workResult.Data;
                var title = "Yeni İş Ataması";
                var message = $"Size yeni bir iş atandı: {workDetail.Name}";
                var actionUrl = $"/Project/Detail/{workDetail.LineId}"; // ActionUrl can be determined by LineId, or we need to add ProjectId to ViewModel.

                await CreateInAppNotificationAsync(userId, title, message, "ViewWork", workId, actionUrl);

                return Response.Success(200, "Bildirim başarıyla gönderildi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Bildirim gönderilemedi", ex.Message, false);
            }
        }

        public async Task<Response> NotifyProjectLineAddedAsync(string projectLineId, string assignedUserId)
        {
            try
            {
                var lineResult = await _projectLineService.GetProjectLineDetailAsync(projectLineId);
                if (!lineResult.IsSuccess || lineResult.Data == null)
                {
                    return Response.Fail(404, "Faz bulunamadı", "Faz bilgilerine ulaşılamadı", true);
                }

                var line = lineResult.Data;
                var title = "Yeni Proje Fazı Ataması";
                var message = $"{line.Project.ProjectName} projesinde '{line.Title}' adlı yeni bir faz size atandı.";
                var actionUrl = $"/Project/Detail/{line.ProjectId}";

                await CreateInAppNotificationAsync(assignedUserId, title, message, "ViewProject", line.ProjectId, actionUrl);

                return Response.Success(200, "Bildirim başarıyla gönderildi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Bildirim gönderilemedi", ex.Message, false);
            }
        }

        public async Task<Response> NotifyProjectLineStatusChangedAsync(string projectLineId, ProjectLineStatusEnum newStatus)
        {
            try
            {
                var lineResult = await _projectLineService.GetProjectLineDetailAsync(projectLineId);
                if (!lineResult.IsSuccess || lineResult.Data == null)
                {
                    return Response.Fail(404, "Faz bulunamadı", "Faz bilgilerine ulaşılamadı", true);
                }

                var line = lineResult.Data;
                var statusText = GetLineStatusText(newStatus);
                var assignedUserId = line.LineOffcial?.Id;

                if (!string.IsNullOrEmpty(assignedUserId))
                {
                    var title = "Faz Durumu Değişti";
                    var message = $"'{line.Title}' fazının durumu '{statusText}' olarak güncellendi.";
                    var actionUrl = $"/Project/Detail/{line.ProjectId}";

                    await CreateInAppNotificationAsync(assignedUserId, title, message, "ViewProject", line.ProjectId, actionUrl);
                }

                return Response.Success(200, "Bildirim başarıyla gönderildi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Bildirim gönderilemedi", ex.Message, false);
            }
        }

        public async Task<Response> CreateInAppNotificationAsync(string userId, string title, string message, string? actionType = null, string? entityId = null, string? actionUrl = null)
        {
            try
            {
                var notification = new AppNotification
                {
                    UserId = userId,
                    Title = title,
                    Message = message,
                    ActionType = actionType,
                    EntityId = entityId,
                    ActionUrl = actionUrl,
                    IsRead = false,
                    CreateTime = DateTime.Now,
                    Status = StatusEnum.Active
                };

                await _notificationRepository.AddAsync(notification);
                await _unitOfWork.CommitAsync();

                return Response.Success(200, "Bildirim oluşturuldu");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "Bildirim oluşturulamadı", ex.Message, false);
            }
        }

        public async Task<Response<List<AppNotificationViewModel>>> GetUserNotificationsAsync(string userId, bool unreadOnly = false)
        {
            try
            {
                var query = _notificationRepository.Where(n => n.UserId == userId && n.Status == StatusEnum.Active);

                if (unreadOnly)
                {
                    query = query.Where(n => !n.IsRead);
                }

                var notifications = await query
                    .OrderByDescending(n => n.CreateTime)
                    .Take(50)
                    .ToListAsync();

                var viewModels = _mapper.Map<List<AppNotificationViewModel>>(notifications);

                // Add TimeAgo calculation
                foreach (var vm in viewModels)
                {
                    vm.TimeAgo = GetTimeAgo(vm.CreateTime);
                }

                return Response<List<AppNotificationViewModel>>.SuccessData(200, "Bildirimler alındı", viewModels);
            }
            catch (Exception ex)
            {
                return Response<List<AppNotificationViewModel>>.FailData(400, "Bildirimler alınamadı", ex.Message, false);
            }
        }

        public async Task<Response> MarkNotificationAsReadAsync(string notificationId, string userId)
        {
            try
            {
                var notification = await _notificationRepository
                    .Where(n => n.Id == notificationId && n.UserId == userId)
                    .FirstOrDefaultAsync();

                if (notification == null)
                {
                    return Response.Fail(404, "Bildirim bulunamadı", "Bildirime ulaşılamadı", true);
                }

                notification.IsRead = true;
                notification.ReadAt = DateTime.Now;
                notification.UpdateTime = DateTime.Now;

                _notificationRepository.Update(notification);
                await _unitOfWork.CommitAsync();

                return Response.Success(200, "Bildirim okundu olarak işaretlendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "İşlem başarısız", ex.Message, false);
            }
        }

        public async Task<Response> MarkAllNotificationsAsReadAsync(string userId)
        {
            try
            {
                var notifications = await _notificationRepository
                    .Where(n => n.UserId == userId && !n.IsRead && n.Status == StatusEnum.Active)
                    .ToListAsync();

                foreach (var notification in notifications)
                {
                    notification.IsRead = true;
                    notification.ReadAt = DateTime.Now;
                    notification.UpdateTime = DateTime.Now;
                    _notificationRepository.Update(notification);
                }

                await _unitOfWork.CommitAsync();

                return Response.Success(200, $"{notifications.Count} bildirim okundu olarak işaretlendi");
            }
            catch (Exception ex)
            {
                return Response.Fail(400, "İşlem başarısız", ex.Message, false);
            }
        }

        private async Task SendEmailNotificationAsync(string userId, string subject, string message, string actionUrl)
        {
            try
            {
                var userResult = await _userService.GetUserInfoById(userId);
                if (userResult.IsSuccess && userResult.Data != null)
                {
                    // Email sending logic would go here
                    // For now, this is a placeholder
                }
            }
            catch
            {
                // Silently fail for email errors
            }
        }

        private string GetProjectStatusText(ProjectStatusEnum status)
        {
            return status switch
            {
                ProjectStatusEnum.Created => "Oluşturuldu",
                ProjectStatusEnum.Started => "Başladı",
                ProjectStatusEnum.Testing => "Test Ediliyor",
                ProjectStatusEnum.Finished => "Tamamlandı",
                ProjectStatusEnum.Canceled => "İptal Edildi",
                ProjectStatusEnum.Failed => "Başarısız",
                _ => status.ToString()
            };
        }

        private string GetLineStatusText(ProjectLineStatusEnum status)
        {
            return status switch
            {
                ProjectLineStatusEnum.NotStarted => "Başlamadı",
                ProjectLineStatusEnum.InProgress => "Devam Ediyor",
                ProjectLineStatusEnum.Completed => "Tamamlandı",
                ProjectLineStatusEnum.WaitingForSomeoneElse => "Başkasını Bekliyor",
                ProjectLineStatusEnum.Deferred => "Ertelendi",
                ProjectLineStatusEnum.Cancellled => "İptal Edildi",
                _ => status.ToString()
            };
        }

        private string GetTimeAgo(DateTime dateTime)
        {
            var span = DateTime.Now - dateTime;

            if (span.TotalMinutes < 1)
                return "Az önce";
            if (span.TotalMinutes < 60)
                return $"{(int)span.TotalMinutes} dakika önce";
            if (span.TotalHours < 24)
                return $"{(int)span.TotalHours} saat önce";
            if (span.TotalDays < 7)
                return $"{(int)span.TotalDays} gün önce";
            if (span.TotalDays < 30)
                return $"{(int)(span.TotalDays / 7)} hafta önce";
            if (span.TotalDays < 365)
                return $"{(int)(span.TotalDays / 30)} ay önce";

            return $"{(int)(span.TotalDays / 365)} yıl önce";
        }
    }
}
