using AutoMapper;
using Humanizer;
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
		public async Task<IActionResult> CreateSong(CreateSongDto createSongDto)
		{
			ViewBag.v1 = "Müzikler";
			ViewBag.v2 = "Müzikler";
			ViewBag.v3 = "Yeni Müzik Ekle";

			if (!ModelState.IsValid)
				return View(createSongDto);

			if (createSongDto.SongFile != null && createSongDto.SongFile.Length > 0)
			{
				var extension = Path.GetExtension(createSongDto.SongFile.FileName);

				var rawName = $"{createSongDto.SongName}_{createSongDto.Singer}";
				var safeName = string.Concat(rawName.Split(Path.GetInvalidFileNameChars()))
					.Replace(" ", "_")
					.ToLower();

				var fileName = $"{safeName}_{Guid.NewGuid()}{extension}";
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/songs", fileName);

				using (var stream = new FileStream(path, FileMode.Create))
				{
					await createSongDto.SongFile.CopyToAsync(stream);
				}

				var song = new Song
				{
					SongName = createSongDto.SongName,
					Singer = createSongDto.Singer,
					SongUrl = "songs/" + fileName
				};

				_songService.TAdd(song);
			}

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
		public async Task<IActionResult> UpdateSongAsync(UpdateSongDto updateSongDto)
		{
			ViewBag.v1 = "Müzikler";
			ViewBag.v2 = "Müzikler";
			ViewBag.v3 = "Müzik Güncelle";

			if (!ModelState.IsValid)
			{
				return View(updateSongDto);
			}

			var song = _songService.TGetById(updateSongDto.SongId);

			// Yeni dosya yüklendiyse
			song.SongName = updateSongDto.SongName;
			song.Singer = updateSongDto.Singer;

			if (updateSongDto.SongFile != null && updateSongDto.SongFile.Length > 0)
			{
				var extension = Path.GetExtension(updateSongDto.SongFile.FileName);

				var rawName = $"{updateSongDto.SongName}_{updateSongDto.Singer}";
				var safeName = string.Concat(rawName.Split(Path.GetInvalidFileNameChars()))
					.Replace(" ", "_")
					.ToLower();

				var fileName = $"{safeName}_{Guid.NewGuid()}{extension}";
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/songs", fileName);

				using (var stream = new FileStream(path, FileMode.Create))
				{
					await updateSongDto.SongFile.CopyToAsync(stream);
				}

				// Yeni dosya varsa eski url yerine yeni url'yi yaz
				song.SongUrl = "songs/" + fileName;
			}
			else
			{
				// Dosya yüklenmediyse mevcut dosya yolunu koru
				song.SongUrl = updateSongDto.SongUrl;
			}

			_songService.TUpdate(song);
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
