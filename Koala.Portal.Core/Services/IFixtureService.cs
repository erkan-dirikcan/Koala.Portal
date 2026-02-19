using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.Services
{
    public interface IFixtureService
    {
        Task<Response<DetailFixtureViewModel>?> GetByIdAsyc(string id);
        Task<Response<UpdateFixtureViewModel>?> GetUpdateDataAsyc(string id);
        Task<Response<List<FixtureListViewModel>>> GetAllAsync(); 
        Task<Response> AddAsyc(CreateFixtureViewModel dto);
        Task<Response> Update(UpdateFixtureViewModel dto, string id);
    }
}
