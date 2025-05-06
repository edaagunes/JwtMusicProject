using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.DataAccessLayer.Context;
using JwtMusic.DataAccessLayer.Repositories;
using JwtMusic.EntityLayer.Entities;
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
		public EfAppUserDal(JwtMusicContext context) : base(context)
		{
			_context = context;
		}

		public List<AppUser> GetPackageNameWithUserList()
		{
			var values=_context.AppUsers.Include(x=>x.Package).ToList();
			return values;
		}
	}
}
