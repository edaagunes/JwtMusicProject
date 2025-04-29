using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.ViewComponents.UILayout
{
	public class _BannerComponentPartial:ViewComponent
	{
		private readonly IBannerService _bannerService;
		private readonly IMapper _mapper;

		public _BannerComponentPartial(IBannerService bannerService, IMapper mapper)
		{
			_bannerService = bannerService;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke()
		{
			var values = _bannerService.TGetAll();
			var result = _mapper.Map<List<ResultBannerDto>>(values);
			return View(result);
		}
	}
}
