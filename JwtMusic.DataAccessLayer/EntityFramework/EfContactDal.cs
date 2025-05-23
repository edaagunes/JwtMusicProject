﻿using JwtMusic.DataAccessLayer.Abstract;
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
	public class EfContactDal : GenericRepository<Contact>, IContactDal
	{
		public EfContactDal(JwtMusicContext context) : base(context)
		{
		}
	}
}
