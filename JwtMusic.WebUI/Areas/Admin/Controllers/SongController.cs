using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.SongDtos;
using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SongController : Controller
	{
		private readonly ISongService _songService;
		private readonly IMapper _mapper;

		public SongController(IMapper mapper, ISongService songService)
		{
			_mapper = mapper;
			_songService = songService;
		}

		public IActionResult SongList()
		{
			ViewBag.v1 = "Müzikler";
			ViewBag.v2 = "Müzikler";
			ViewBag.v3 = "Müzik Listesi";

			var values = _songService.TGetAll();
			var resultDtos = _mapper.Map<List<ResultSongDto>>(values);
			return View(resultDtos);
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public IActionResult CreateSong()
		{
			ViewBag.v1 = "Müzikler";
			ViewBag.v2 = "Müzikler";
			ViewBag.v3 = "Yeni Müzik Ekle";

			return View();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult CreateSong(CreateSongDto createSongDto)
		{
			ViewBag.v1 = "Müzikler";
			ViewBag.v2 = "Müzikler";
			ViewBag.v3 = "Yeni Müzik Ekle";

			if (!ModelState.IsValid)
			{
				return View(createSongDto);
			}

			var values = _mapper.Map<Song>(createSongDto);
			_songService.TAdd(values);
			return RedirectToAction("SongList", "Song", new { area = "Admin" });
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public IActionResult UpdateSong(int id)
		{
			ViewBag.v1 = "Müzikler";
			ViewBag.v2 = "Müzikler";
			ViewBag.v3 = "Müzik Güncelle";

			var values = _songService.TGetById(id);
			var updateSongDto = _mapper.Map<UpdateSongDto>(values);
			return View(updateSongDto);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult UpdateSong(UpdateSongDto updateSongDto)
		{
			ViewBag.v1 = "Müzikler";
			ViewBag.v2 = "Müzikler";
			ViewBag.v3 = "Müzik Güncelle";

			if (!ModelState.IsValid)
			{
				return View(updateSongDto);
			}

			var values = _songService.TGetById(updateSongDto.SongId);
			_mapper.Map(updateSongDto, values);
			_songService.TUpdate(values);
			return RedirectToAction("SongList", "Song", new { area = "Admin" });
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult DeleteSong(int id)
		{
			var values = _songService.TGetById(id);
			if (values != null)
			{
				_songService.TDelete(values);
				var deletedSong = _songService.TGetById(id);
				if (deletedSong == null)
				{
					return Json(new { success = true });
				}
			}
			return Json(new { success = false, message = "Silme işlemi sırasında bir hata oluştu." });
		}
	}
}
