using Koala.Portal.Core.GetPassModels;

namespace Koala.Portal.Core.GetPassRepositories;

public interface IGetPassUserRepository:IGetPassBaseRepository<AspNetUsers>
{
	Task<AspNetUsers> GetUserInfoByIdAsync(string id);
    Task<AspNetUsers> GetUserInfoByEmailAsync(string email);
    Task<AspNetUsers> GetUserInfoBySkeyAsync(string sKey);
}