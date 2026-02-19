using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.CrmViewModels;

namespace Koala.Portal.Core.Services;

public interface IFirmContactService
{
    Task<Response<List<CrmFirmContactListViewModel>>> GetAllAsync(string firmId);
    Task<Response<List<CrmFirmContactListViewModel>>> GetAllByOidAsync(string firmOid);
    Task<Response<string>> GetOidAsync(string id);
    Task<Response<string>> GetIdAsync(string oid);
    Task<Response<CrmFirmContactDetailViewModel>> GetDetailAsync(string contactId);
    Task<Response<CrmFirmContactDetailViewModel>> GetDetailByOidAsync(string contactOid);


}