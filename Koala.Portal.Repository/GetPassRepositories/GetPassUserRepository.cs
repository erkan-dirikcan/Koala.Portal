using Koala.Portal.Core.GetPassModels;
using Koala.Portal.Core.GetPassRepositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.GetPassRepositories;

public class GetPassUserRepository : GetPassBaseRepository<AspNetUsers>, IGetPassUserRepository
{
	private readonly SistemCryptorContext _context;
	public GetPassUserRepository( SistemCryptorContext context) : base(context)
	{
		_context = context;
	}

    public async Task<AspNetUsers> GetUserInfoByEmailAsync(string email)
    {
        var res = await _context.AspNetUsers.FirstOrDefaultAsync(x => x.Email == email);
        return res;
    }

    public async Task<AspNetUsers> GetUserInfoByIdAsync(string id)
    {
        var res= await _context.AspNetUsers.FirstOrDefaultAsync(x => x.Id == id);
		return res;
    }

    public async Task<AspNetUsers> GetUserInfoBySkeyAsync(string sKey)
    {
        var res = await _context.AspNetUsers.FirstOrDefaultAsync(x => x.SecretKey == sKey);
        return res;
    }
}