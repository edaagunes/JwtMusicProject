using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.DjInfoDtos;
using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DjInfoController : Controller
	{
		private readonly IDjInfoService _djInfoService;
		private readonly IMapper _mapper;

		public DjInfoController(IMapper mapper, IDjInfoService djInfoService)
		{
			_mapper = mapper;
			_djInfoService = djInfoService;
		}

		public IActionResult DjInfoList()
		{
			ViewBag.v1 = "Dj Bilgisi";
			ViewBag.v2 = "Dj Bilgisi";
			ViewBag.v3 = "Dj Bilgisi Listesi";

			var values = _djInfoService.TGetAll();
			var resultDtos = _mapper.Map<List<ResultDjInfoDto>>(values);
			return View(resultDtos);
		}

		[HttpGet]
		public IActionResult CreateDjInfo()
		{
			ViewBag.v1 = "Dj Bilgisi";
			ViewBag.v2 = "Dj Bilgisi";
			ViewBag.v3 = "Yeni Dj Bilgisi Ekle";

			return View();
		}

		[HttpPost]
		public IActionResult CreateDjInfo(CreateDjInfoDto createDjInfoDto)
		{
			ViewBag.v1 = "Dj Bilgisi";
			ViewBag.v2 = "Dj Bilgisi";
			ViewBag.v3 = "Yeni Dj Bilgisi Ekle";

			if (!ModelState.IsValid)
			{
				return View(createDjInfoDto);
			}

			var values = _mapper.Map<DjInfo>(createDjInfoDto);
			_djInfoService.TAdd(values);
			return RedirectToAction("DjInfoList", "DjInfo", new { area = "Admin" });
		}

		[HttpGet]
		public IActionResult UpdateDjInfo(int id)
		{
			ViewBag.v1 = "Dj Bilgisi";
			ViewBag.v2 = "Dj Bilgisi";
			ViewBag.v3 = "Dj Bilgisi Güncelle";

			var values = _djInfoService.TGetById(id);
			var updateDjInfoDto = _mapper.Map<UpdateDjInfoDto>(values);
			return View(updateDjInfoDto);
		}

		[HttpPost]
		public IActionResult UpdateDjInfo(UpdateDjInfoDto updateDjInfoDto)
		{
			ViewBag.v1 = "Dj Bilgisi";
			ViewBag.v2 = "Dj Bilgisi";
			ViewBag.v3 = "Dj Bilgisi Güncelle";

			if (!ModelState.IsValid)
			{
				return View(updateDjInfoDto);
			}

			var values = _djInfoService.TGetById(updateDjInfoDto.DjInfoId);
			_mapper.Map(updateDjInfoDto, values);
			_djInfoService.TUpdate(values);
			return RedirectToAction("DjInfoList", "DjInfo", new { area = "Admin" });
		}

		[HttpPost]
		public IActionResult DeleteDjInfo(int id)
		{
			var values = _djInfoService.TGetById(id);
			if (values != null)
			{
				_djInfoService.TDelete(values);
				var deletedDjInfo = _djInfoService.TGetById(id);
				if (deletedDjInfo == null)
				{
					return Json(new { success = true });
				}
			}
			return Json(new { success = false, message = "Silme işlemi sırasında bir hata oluştu." });
		}
	}
}
