using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.DjInfoDtos;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.ViewComponents.UILayout
{
	public class _AboutComponentPartial:ViewComponent
	{
		private readonly IDjInfoService _djInfoService;
		private readonly IMapper _mapper;

		public _AboutComponentPartial(IDjInfoService djInfoService, IMapper mapper)
		{
			_djInfoService = djInfoService;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke()
		{
			var values = _djInfoService.TGetAll();
			var result = _mapper.Map<List<ResultDjInfoDto>>(values);
			return View(result);
		}
	}
}
