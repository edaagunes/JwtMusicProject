using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.EntityLayer.Entities;

namespace JwtMusic.BusinessLayer.Concrete
{
	public class CountDownManager : ICountDownService
	{
		private readonly ICountDownDal _countDownDal;

		public CountDownManager(ICountDownDal countDownDal)
		{
			_countDownDal = countDownDal;
		}

		public void TAdd(CountDown entity)
		{
			_countDownDal.Add(entity);
		}

		public void TDelete(CountDown entity)
		{
			_countDownDal.Delete(entity);
		}

		public List<CountDown> TGetAll()
		{
			return _countDownDal.GetAll();
		}

		public CountDown TGetById(int id)
		{
			return _countDownDal.GetById(id);
		}

		public void TUpdate(CountDown entity)
		{
			_countDownDal.Update(entity);
		}
	}
}
