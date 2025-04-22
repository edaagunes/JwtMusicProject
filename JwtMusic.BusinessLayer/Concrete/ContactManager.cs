using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.EntityLayer.Entities;

namespace JwtMusic.BusinessLayer.Concrete
{
	public class ContactManager : IContactService
	{
		private readonly IContactDal _contactDal;

		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

		public void TAdd(Contact entity)
		{
			_contactDal.Add(entity);
		}

		public void TDelete(Contact entity)
		{
			_contactDal.Delete(entity);
		}

		public List<Contact> TGetAll()
		{
			return _contactDal.GetAll();
		}

		public Contact TGetById(int id)
		{
			return _contactDal.GetById(id);
		}

		public void TUpdate(Contact entity)
		{
			_contactDal.Update(entity);
		}
	}
}
