using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.EntityLayer.Entities;

namespace JwtMusic.BusinessLayer.Concrete
{
	public class BannerManager:IBannerService
	{
		private readonly IBannerDal _bannerDal;

		public BannerManager(IBannerDal bannerDal)
		{
			_bannerDal = bannerDal;
		}

		public void TAdd(Banner entity)
		{
			_bannerDal.Add(entity);
		}

		public void TDelete(Banner entity)
		{
			_bannerDal.Delete(entity);
		}

		public List<Banner> TGetAll()
		{
			return _bannerDal.GetAll();
		}

		public Banner TGetById(int id)
		{
			return _bannerDal.GetById(id);
		}

		public void TUpdate(Banner entity)
		{
			_bannerDal.Update(entity);
		}
	}
}
