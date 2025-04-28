using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.BannerDtos;
using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BannerController : Controller
	{
		private readonly IBannerService _bannerService;
		private readonly IMapper _mapper;

		public BannerController(IMapper mapper, IBannerService bannerService)
		{
			_mapper = mapper;
			_bannerService = bannerService;
		}

		public IActionResult BannerList()
		{
			ViewBag.v1 = "Banner";
			ViewBag.v2 = "Banner";
			ViewBag.v3 = "Banner Listesi";

			var values = _bannerService.TGetAll();
			var resultDtos = _mapper.Map<List<ResultBannerDto>>(values);
			return View(resultDtos);
		}

		[HttpGet]
		public IActionResult CreateBanner()
		{
			ViewBag.v1 = "Banner";
			ViewBag.v2 = "Banner";
			ViewBag.v3 = "Yeni Banner Ekle";

			return View();
		}

		[HttpPost]
		public IActionResult CreateBanner(CreateBannerDto createBannerDto)
		{
			ViewBag.v1 = "Banner";
			ViewBag.v2 = "Banner";
			ViewBag.v3 = "Yeni Banner Ekle";

			if (!ModelState.IsValid)
			{
				return View(createBannerDto);
			}

			var values = _mapper.Map<Banner>(createBannerDto);
			_bannerService.TAdd(values);
			return RedirectToAction("BannerList", "Banner", new { area = "Admin" });
		}

		[HttpGet]
		public IActionResult UpdateBanner(int id)
		{
			ViewBag.v1 = "Banner";
			ViewBag.v2 = "Banner";
			ViewBag.v3 = "Banner Güncelle";

			var values = _bannerService.TGetById(id);
			var updateBannerDto = _mapper.Map<UpdateBannerDto>(values);
			return View(updateBannerDto);
		}

		[HttpPost]
		public IActionResult UpdateBanner(UpdateBannerDto updateBannerDto)
		{
			ViewBag.v1 = "Banner";
			ViewBag.v2 = "Banner";
			ViewBag.v3 = "Banner Güncelle";

			if (!ModelState.IsValid)
			{
				return View(updateBannerDto);
			}

			var values = _bannerService.TGetById(updateBannerDto.BannerId);
			_mapper.Map(updateBannerDto, values);
			_bannerService.TUpdate(values);
			return RedirectToAction("BannerList", "Banner", new { area = "Admin" });
		}

		[HttpPost]
		public IActionResult DeleteBanner(int id)
		{
			var values = _bannerService.TGetById(id);
			if (values != null)
			{
				_bannerService.TDelete(values);
				var deletedBanner = _bannerService.TGetById(id);
				if (deletedBanner == null)
				{
					return Json(new { success = true });
				}
			}
			return Json(new { success = false, message = "Silme işlemi sırasında bir hata oluştu." });
		}
	}
}
