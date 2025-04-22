using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.EntityLayer.Entities;

namespace JwtMusic.BusinessLayer.Concrete
{
	public class DjInfoManager:IDjInfoService
	{
		private readonly IDjInfoDal _djInfoDal;

		public DjInfoManager(IDjInfoDal djInfoDal)
		{
			_djInfoDal = djInfoDal;
		}

		public void TAdd(DjInfo entity)
		{
			_djInfoDal.Add(entity);
		}

		public void TDelete(DjInfo entity)
		{
			_djInfoDal.Delete(entity);
		}

		public List<DjInfo> TGetAll()
		{
			return _djInfoDal.GetAll();
		}

		public DjInfo TGetById(int id)
		{
			return _djInfoDal.GetById(id);
		}

		public void TUpdate(DjInfo entity)
		{
			_djInfoDal.Update(entity);
		}
	}
}
