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
	public class EfSongDal : GenericRepository<Song>, ISongDal
	{
		private readonly JwtMusicContext _context;
		public EfSongDal(JwtMusicContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Song> GetSongByUrl(string songUrl)
		{
			return await _context.Songs
	.Include(s => s.Packages)
	.FirstOrDefaultAsync(s => s.SongUrl.ToLower() == songUrl.ToLower());

		}
	}
}
