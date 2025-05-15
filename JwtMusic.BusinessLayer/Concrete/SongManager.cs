using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DataAccessLayer.Abstract;
using JwtMusic.EntityLayer.Entities;

namespace JwtMusic.BusinessLayer.Concrete
{
	public class SongManager : ISongService
	{
		private readonly ISongDal _songDal;

		public SongManager(ISongDal songDal)
		{
			_songDal = songDal;
		}

		public void TAdd(Song entity)
		{
			_songDal.Add(entity);
		}

		public void TDelete(Song entity)
		{
			_songDal.Delete(entity);
		}

		public List<Song> TGetAll()
		{
			return _songDal.GetAll();
		}

		public Song TGetById(int id)
		{
			return _songDal.GetById(id);
		}

		public Task<Song> TGetSongByUrl(string songUrl)
		{
			return _songDal.GetSongByUrl(songUrl);
		}

		public void TUpdate(Song entity)
		{
			_songDal.Update(entity);
		}
	}
}
