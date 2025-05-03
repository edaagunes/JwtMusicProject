using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.CountDownDtos;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.ViewComponents.UILayout
{
	public class _CountDownComponentPartial:ViewComponent
	{
		private readonly ICountDownService _countDownService;
		private readonly IMapper _mapper;

		public _CountDownComponentPartial(ICountDownService countDownService, IMapper mapper)
		{
			_countDownService = countDownService;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke()
		{
			var values = _countDownService.TGetById(1);
			var result = _mapper.Map<ResultCountDownDto>(values);
			return View(result);
		}
	}
}
