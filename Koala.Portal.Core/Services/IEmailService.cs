using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.Services;

public interface IEmailService
{
    Task<bool> SendResetPasswordEmailAsync(ResetPasswordEmailDto model);
    Task<bool> SendChangePasswordEmailAsync(CustomEmailDto model);
    Task<bool> SendProjectEmailAsync(ProjectCustomEmailDto model);

}