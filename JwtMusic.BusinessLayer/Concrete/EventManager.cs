using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.EntityLayer.Entities;

namespace JwtMusic.BusinessLayer.Concrete
{
	public class EventManager : IEventService
	{
		private readonly IEventDal _eventDal;

		public EventManager(IEventDal eventDal)
		{
			_eventDal = eventDal;
		}

		public void TAdd(Event entity)
		{
			_eventDal.Add(entity);
		}

		public void TDelete(Event entity)
		{
			_eventDal.Delete(entity);
		}

		public List<Event> TGetAll()
		{
			return _eventDal.GetAll();
		}

		public Event TGetById(int id)
		{
			return _eventDal.GetById(id);
		}

		public void TUpdate(Event entity)
		{
			_eventDal.Update(entity);
		}
	}
}
