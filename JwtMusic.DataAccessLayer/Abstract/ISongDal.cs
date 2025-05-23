﻿using JwtMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DataAccessLayer.Abstract
{
	public interface ISongDal : IGenericDal<Song>
	{
		Task<Song> GetSongByUrl(string songUrl);
	}
}
