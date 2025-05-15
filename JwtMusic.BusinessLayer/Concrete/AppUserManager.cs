using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.DataAccessLayer.EntityFramework;
using JwtMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Concrete
{
	public class AppUserManager : IAppUserService
	{
		private readonly IAppUserDal _appUserDal;

		public AppUserManager(IAppUserDal appUserDal)
		{
			_appUserDal = appUserDal;
		}

		public void TAdd(AppUser entity)
		{
			_appUserDal.Add(entity);
		}

		public void TDelete(AppUser entity)
		{
			_appUserDal.Delete(entity);
		}

		public List<AppUser> TGetAll()
		{
			return _appUserDal.GetAll();
		}

		public AppUser TGetById(int id)
		{
			return _appUserDal.GetById(id);
		}

		public List<AppUser> TGetPackageNameWithUserList()
		{
			return _appUserDal.GetPackageNameWithUserList();
		}

		public Task<AppUser> TGetUserById(int userId)
		{
			return _appUserDal.GetUserById(userId);
		}

		public void TUpdate(AppUser entity)
		{
			_appUserDal.Update(entity);
		}
	}
}
