using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.EventDtos;
using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class EventController : Controller
	{
		private readonly IEventService _eventService;
		private readonly IMapper _mapper;

		public EventController(IMapper mapper, IEventService eventService)
		{
			_mapper = mapper;
			_eventService = eventService;
		}

		public IActionResult EventList()
		{
			ViewBag.v1 = "Etkinlik";
			ViewBag.v2 = "Etkinlik";
			ViewBag.v3 = "Etkinlik Listesi";

			var values = _eventService.TGetAll();
			var resultDtos = _mapper.Map<List<ResultEventDto>>(values);
			return View(resultDtos);
		}

		[HttpGet]
		public IActionResult CreateEvent()
		{
			ViewBag.v1 = "Etkinlik";
			ViewBag.v2 = "Etkinlik";
			ViewBag.v3 = "Yeni Etkinlik Ekle";

			return View();
		}

		[HttpPost]
		public IActionResult CreateEvent(CreateEventDto createEventDto)
		{
			ViewBag.v1 = "Etkinlik";
			ViewBag.v2 = "Etkinlik";
			ViewBag.v3 = "Yeni Etkinlik Ekle";

			if (!ModelState.IsValid)
			{
				return View(createEventDto);
			}

			var values = _mapper.Map<Event>(createEventDto);
			_eventService.TAdd(values);
			return RedirectToAction("EventList", "Event", new { area = "Admin" });
		}

		[HttpGet]
		public IActionResult UpdateEvent(int id)
		{
			ViewBag.v1 = "Etkinlik";
			ViewBag.v2 = "Etkinlik";
			ViewBag.v3 = "Etkinlik Güncelle";

			var values = _eventService.TGetById(id);
			var updateEventDto = _mapper.Map<UpdateEventDto>(values);
			return View(updateEventDto);
		}

		[HttpPost]
		public IActionResult UpdateEvent(UpdateEventDto updateEventDto)
		{
			ViewBag.v1 = "Etkinlik";
			ViewBag.v2 = "Etkinlik";
			ViewBag.v3 = "Etkinlik Güncelle";

			if (!ModelState.IsValid)
			{
				return View(updateEventDto);
			}

			var values = _eventService.TGetById(updateEventDto.EventId);
			_mapper.Map(updateEventDto, values);
			_eventService.TUpdate(values);
			return RedirectToAction("EventList", "Event", new { area = "Admin" });
		}

		[HttpPost]
		public IActionResult DeleteEvent(int id)
		{
			var values = _eventService.TGetById(id);
			if (values != null)
			{
				_eventService.TDelete(values);
				var deletedEvent = _eventService.TGetById(id);
				if (deletedEvent == null)
				{
					return Json(new { success = true });
				}
			}
			return Json(new { success = false, message = "Silme işlemi sırasında bir hata oluştu." });
		}
	}
}
