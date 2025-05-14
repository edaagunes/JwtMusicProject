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
	public class EfPackageDal : GenericRepository<Package>, IPackageDal
	{
		private readonly JwtMusicContext _context;
		public EfPackageDal(JwtMusicContext context) : base(context)
		{
			_context = context;
		}

		public Package GetPackageWithSongsById(int id)
		{
			return _context.Packages.Include(p => p.Songs).FirstOrDefault(p => p.PackageId == id);
		}

		public List<Song> GetSongsByPackageId(int packageId)
		{
			var values= _context.Songs.Where(song => song.Packages.Any(p => p.PackageId == packageId)).ToList();
			return values;
		}
	}
}
