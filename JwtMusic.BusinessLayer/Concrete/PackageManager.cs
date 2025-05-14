using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.EntityLayer.Entities;

namespace JwtMusic.BusinessLayer.Concrete
{
	public class PackageManager : IPackageService
	{
		private readonly IPackageDal _packageDal;

		public PackageManager(IPackageDal packageDal)
		{
			_packageDal = packageDal;
		}

		public void TAdd(Package entity)
		{
			_packageDal.Add(entity);
		}

		public void TDelete(Package entity)
		{
			_packageDal.Delete(entity);
		}

		public List<Package> TGetAll()
		{
			return _packageDal.GetAll();
		}

		public Package TGetById(int id)
		{
			return _packageDal.GetById(id);
		}

		public Package TGetPackageWithSongsById(int id)
		{
			return _packageDal.GetPackageWithSongsById(id);
		}

		public List<Song> TGetSongsByPackageId(int packageId)
		{
			return _packageDal.GetSongsByPackageId(packageId);
		}

		public void TUpdate(Package entity)
		{
			_packageDal.Update(entity);
		}
	}
}
