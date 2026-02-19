using Koala.Portal.Core.Dtos;

namespace Koala.Portal.Core.Services;

public interface IBackgroundServices
{
    Task<Response> SencronFirm();
    void SencronFirmJob();
}