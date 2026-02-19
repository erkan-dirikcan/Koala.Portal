using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<AppUser> _userManager;
        public readonly AppDbContext _context;
        public readonly DbSet<AppUser> _dbSet;

        public UserRepository(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
            _dbSet = _context.Set<AppUser>();
        }

        public async Task<AppUser?> GetUserInfoById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<AppUser?> GetUserInfoByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<AppUser?> GetUserInfoByOid(string oid)
        {
            //if (string.IsNullOrEmpty(oid))
            //{
            //    return null;
            //}
            //if (!_dbSet.Any(x => x.Oid == oid))
            //{
            //    return null;
            //}
            var user = await _dbSet.FirstOrDefaultAsync(x => x.Oid == oid);
            return user;
        }
        public async Task<List<AppUser>> GetUserActiveList()
        {
            var users = await _dbSet.Where(x => x.Status == UserStatusEnum.Active).ToListAsync();
            return users;
        }

        public async Task<List<KeyValuePair<string, string>>> GetUserAvatarList(List<string> oids)
        {
            var users = await _dbSet.Where(x => oids.Any(y => x.Oid == y)).Select(x=>new KeyValuePair<string,string>(x.Oid,x.Avatar)).ToListAsync();
            return users;
        }

        public async Task<List<AppUser>> GetUsers()
        {
           return await _userManager.Users.Where(x=>x.Status==UserStatusEnum.Active).ToListAsync();
        }
    }

}
