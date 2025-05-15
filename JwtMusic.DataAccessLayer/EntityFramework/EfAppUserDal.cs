using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.DataAccessLayer.Context;
using JwtMusic.DataAccessLayer.Repositories;
using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DataAccessLayer.EntityFramework
{
	public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
	{
		private readonly JwtMusicContext _context;
		private readonly UserManager<AppUser> _userManager;
		public EfAppUserDal(JwtMusicContext context, UserManager<AppUser> userManager) : base(context)
		{
			_context = context;
			_userManager = userManager;
		}

		public List<AppUser> GetPackageNameWithUserList()
		{
			var values=_context.AppUsers.Include(x=>x.Package).ToList();
			return values;
		}

		public async Task<AppUser> GetUserById(int userId)
		{
			return await _userManager.FindByIdAsync(userId.ToString());
		}
	}
}
