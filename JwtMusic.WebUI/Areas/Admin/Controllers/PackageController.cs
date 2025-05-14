using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.PackageDtos;
using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PackageController : Controller
	{
		private readonly IPackageService _packageService;
		private readonly ISongService _songService;
		private readonly IMapper _mapper;

		public PackageController(IMapper mapper, IPackageService packageService, ISongService songService)
		{
			_mapper = mapper;
			_packageService = packageService;
			_songService = songService;
		}

		public IActionResult PackageList()
		{
			ViewBag.v1 = "Paketler";
			ViewBag.v2 = "Paketler";
			ViewBag.v3 = "Paket Listesi";

			var values = _packageService.TGetAll();
			var resultDtos = _mapper.Map<List<ResultPackageDto>>(values);
			return View(resultDtos);
		}

		[HttpGet]
		public IActionResult CreatePackage()
		{
			ViewBag.v1 = "Paketler";
			ViewBag.v2 = "Paketler";
			ViewBag.v3 = "Yeni Paket Ekle";

			var songs = _songService.TGetAll();
			ViewBag.Songs = new SelectList(songs, "SongId", "SongName");

			return View();
		}

		[HttpPost]
		public IActionResult CreatePackage(CreatePackageDto createPackageDto)
		{
			ViewBag.v1 = "Paketler";
			ViewBag.v2 = "Paketler";
			ViewBag.v3 = "Yeni Paket Ekle";

			ViewBag.v1 = "Paketler";
			ViewBag.v2 = "Paketler";
			ViewBag.v3 = "Yeni Paket Ekle";

			var songs = _songService.TGetAll();
			ViewBag.Songs = new SelectList(songs, "SongId", "SongName");

			if (!ModelState.IsValid)
			{
				return View(createPackageDto);
			}

			var package = new Package
			{
				Name = createPackageDto.Name,
				Songs = new List<Song>()
			};

			if (createPackageDto.SongIds != null)
			{
				var selectedSongs = songs.Where(song => createPackageDto.SongIds.Contains(song.SongId)).ToList();
				foreach (var song in selectedSongs)
				{
					package.Songs.Add(song);
				}
			}

			_packageService.TAdd(package);

			return RedirectToAction("PackageList", "Package", new { area = "Admin" });
		}

		[HttpPost]
		public IActionResult DeletePackage(int id)
		{
			var values = _packageService.TGetById(id);
			if (values != null)
			{
				_packageService.TDelete(values);
				var deletedPackage = _packageService.TGetById(id);
				if (deletedPackage == null)
				{
					return Json(new { success = true });
				}
			}
			return Json(new { success = false, message = "Silme işlemi sırasında bir hata oluştu." });
		}

		[HttpGet]
		public IActionResult UpdatePackage(int id)
		{
			ViewBag.v1 = "Paketler";
			ViewBag.v2 = "Paketler";
			ViewBag.v3 = "Paketi Güncelle";

			var values = _packageService.TGetPackageWithSongsById(id);
			var updatePackageDto = _mapper.Map<UpdatePackageDto>(values);

			// Şu anki şarkı ID'leri ve adları
			updatePackageDto.SongIds = values.Songs?.Select(s => s.SongId).ToList();
			updatePackageDto.CurrentSongNames = values.Songs?.Select(s => s.SongName).ToList();

			var songs = _songService.TGetAll();
			ViewBag.Songs = new SelectList(songs, "SongId", "SongName");

			return View(updatePackageDto);
		}


		[HttpPost]
		public IActionResult UpdatePackage(UpdatePackageDto updatePackageDto)
		{
			ViewBag.v1 = "Paketler";
			ViewBag.v2 = "Paketler";
			ViewBag.v3 = "Paketi Güncelle";

			var songs = _songService.TGetAll();
			ViewBag.Songs = new SelectList(songs, "SongId", "SongName");

			if (!ModelState.IsValid)
			{
				return View(updatePackageDto);
			}

			var package = _packageService.TGetPackageWithSongsById(updatePackageDto.PackageId);

			// Paket adını güncelle
			package.Name = updatePackageDto.Name;

			var selectedSongIds = updatePackageDto.SongIds ?? new List<int>();
			var existingSongIds = package.Songs.Select(s => s.SongId).ToList();

			// Yeni eklenenler
			var songsToAddIds = selectedSongIds.Except(existingSongIds).ToList();
			var songsToAdd = songs.Where(song => songsToAddIds.Contains(song.SongId)).ToList();

			// Çıkarılanlar
			var songsToRemoveIds = existingSongIds.Except(selectedSongIds).ToList();
			var songsToRemove = package.Songs.Where(song => songsToRemoveIds.Contains(song.SongId)).ToList();

			// Ekle
			foreach (var song in songsToAdd)
			{
				package.Songs.Add(song);
			}

			// Sil
			foreach (var song in songsToRemove)
			{
				package.Songs.Remove(song);
			}

			// Güncelle
			_packageService.TUpdate(package);

			return RedirectToAction("PackageList", "Package", new { area = "Admin" });
		}

	}
}
