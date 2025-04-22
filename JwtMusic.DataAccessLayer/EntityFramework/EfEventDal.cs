using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.DataAccessLayer.Context;
using JwtMusic.DataAccessLayer.Repositories;
using JwtMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DataAccessLayer.EntityFramework
{
	public class EfEventDal : GenericRepository<Event>, IEventDal
	{
		public EfEventDal(JwtMusicContext context) : base(context)
		{
		}
	}
}
