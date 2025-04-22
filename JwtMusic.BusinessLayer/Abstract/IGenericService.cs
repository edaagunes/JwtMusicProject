using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtMusic.BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		void TAdd(T entity);
		void TUpdate(T entity);
		void TDelete(T entity);
		T TGetById(int id);
		List<T> TGetAll();
	}
}
