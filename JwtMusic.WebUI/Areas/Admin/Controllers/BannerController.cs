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
			var values = _mapper.Map<Banner>(createBannerDto);
			_bannerService.TAdd(values);
			return RedirectToAction("BannerList", "Banner", new { area = "Admin" });
		}
	}
}
