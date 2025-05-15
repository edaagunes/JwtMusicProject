using JwtMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Abstract
{
	public interface IAppUserService : IGenericService<AppUser>
	{
		List<AppUser> TGetPackageNameWithUserList();
		Task<AppUser> TGetUserById(int userId);
	}
}
