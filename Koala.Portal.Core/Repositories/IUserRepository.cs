using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Repositories;

public interface IUserRepository
{
    Task<AppUser?> GetUserInfoById(string id);
    Task<AppUser?> GetUserInfoByEmail(string email);
    Task<AppUser?> GetUserInfoByOid(string oid);
    Task<List<AppUser>> GetUserActiveList();
    Task<List<KeyValuePair<string, string>>> GetUserAvatarList(List<string> oids);
    Task<List<AppUser>> GetUsers();

}