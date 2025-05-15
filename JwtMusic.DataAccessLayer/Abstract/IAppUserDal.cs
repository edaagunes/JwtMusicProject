using JwtMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.DataAccessLayer.Abstract
{
	public interface IAppUserDal : IGenericDal<AppUser>
	{
		List<AppUser> GetPackageNameWithUserList();
		Task<AppUser> GetUserById(int userId);
	}
}
