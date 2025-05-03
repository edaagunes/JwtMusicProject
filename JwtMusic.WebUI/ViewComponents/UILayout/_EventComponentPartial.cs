using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.BannerDtos;
using JwtMusic.DtoLayer.EventDtos;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.ViewComponents.UILayout
{
	public class _EventComponentPartial:ViewComponent
	{
		private readonly IEventService _eventService;
		private readonly IMapper _mapper;

		public _EventComponentPartial(IEventService eventService, IMapper mapper)
		{
			_eventService = eventService;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke()
		{
			var values = _eventService.TGetAll();
			var result = _mapper.Map<List<ResultEventDto>>(values);
			return View(result);
		}
	}
}
