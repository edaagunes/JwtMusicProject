using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.SongDtos;
using JwtMusic.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.ViewComponents.UILayout
{
	public class _SongComponentPartial:ViewComponent
	{
		private readonly ISongService _songService;
		private readonly IMapper _mapper;

		public _SongComponentPartial(ISongService songService, IMapper mapper)
		{
			_songService = songService;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke()
		{
			var values = _songService.TGetAll();
			var result = _mapper.Map<List<ResultSongDto>>(values);
			return View(result);
		}
	}
}
