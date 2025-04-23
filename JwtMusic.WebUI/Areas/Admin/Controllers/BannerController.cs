using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.BannerDtos;
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
			var values = _bannerService.TGetAll();
			var resultDtos = _mapper.Map<List<ResultBannerDto>>(values);
			return View(resultDtos);
		}
	}
}
