using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.CountDownDtos;
using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CountDownController : Controller
	{
		private readonly ICountDownService _countDownService;
		private readonly IMapper _mapper;

		public CountDownController(IMapper mapper, ICountDownService countDownService)
		{
			_mapper = mapper;
			_countDownService = countDownService;
		}

		public IActionResult CountDownList()
		{
			ViewBag.v1 = "Etkinlik Sayacı";
			ViewBag.v2 = "Etkinlik Sayacı";
			ViewBag.v3 = "Etkinlik Sayacı Listesi";

			var values = _countDownService.TGetAll();
			var resultDtos = _mapper.Map<List<ResultCountDownDto>>(values);
			return View(resultDtos);
		}

		[HttpGet]
		public IActionResult CreateCountDown()
		{
			ViewBag.v1 = "Etkinlik Sayacı";
			ViewBag.v2 = "Etkinlik Sayacı";
			ViewBag.v3 = "Yeni Etkinlik Sayacı Ekle";

			return View();
		}

		[HttpPost]
		public IActionResult CreateCountDown(CreateCountDownDto createCountDownDto)
		{
			ViewBag.v1 = "Etkinlik Sayacı";
			ViewBag.v2 = "Etkinlik Sayacı";
			ViewBag.v3 = "Yeni Etkinlik Sayacı Ekle";

			if (!ModelState.IsValid)
			{
				return View(createCountDownDto);
			}

			var values = _mapper.Map<CountDown>(createCountDownDto);
			_countDownService.TAdd(values);
			return RedirectToAction("CountDownList", "CountDown", new { area = "Admin" });
		}

		[HttpGet]
		public IActionResult UpdateCountDown(int id)
		{
			ViewBag.v1 = "Etkinlik Sayacı";
			ViewBag.v2 = "Etkinlik Sayacı";
			ViewBag.v3 = "Etkinlik Sayacı Güncelle";

			var values = _countDownService.TGetById(id);
			var updateCountDownDto = _mapper.Map<UpdateCountDownDto>(values);
			return View(updateCountDownDto);
		}

		[HttpPost]
		public IActionResult UpdateCountDown(UpdateCountDownDto updateCountDownDto)
		{
			ViewBag.v1 = "Etkinlik Sayacı";
			ViewBag.v2 = "Etkinlik Sayacı";
			ViewBag.v3 = "Etkinlik Sayacı Güncelle";

			if (!ModelState.IsValid)
			{
				return View(updateCountDownDto);
			}

			var values = _countDownService.TGetById(updateCountDownDto.CountDownId);
			_mapper.Map(updateCountDownDto, values);
			_countDownService.TUpdate(values);
			return RedirectToAction("CountDownList", "CountDown", new { area = "Admin" });
		}

		[HttpPost]
		public IActionResult DeleteCountDown(int id)
		{
			var values = _countDownService.TGetById(id);
			if (values != null)
			{
				_countDownService.TDelete(values);
				var deletedCountDown = _countDownService.TGetById(id);
				if (deletedCountDown == null)
				{
					return Json(new { success = true });
				}
			}
			return Json(new { success = false, message = "Silme işlemi sırasında bir hata oluştu." });
		}
	}
}
