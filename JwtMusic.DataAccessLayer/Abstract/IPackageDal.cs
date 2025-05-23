﻿using JwtMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DataAccessLayer.Abstract
{
	public interface IPackageDal : IGenericDal<Package>
	{
		List<Song> GetSongsByPackageId(int packageId);
		Package GetPackageWithSongsById(int id);
	}
}
