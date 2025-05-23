﻿using JwtMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Abstract
{
	public interface IPackageService : IGenericService<Package>
	{
		List<Song> TGetSongsByPackageId(int packageId);
		Package TGetPackageWithSongsById(int id);
	}
}
