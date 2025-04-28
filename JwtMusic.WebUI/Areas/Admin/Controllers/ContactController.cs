using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.ContactDtos;
using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactController(IMapper mapper, IContactService bannerService)
		{
			_mapper = mapper;
			_contactService = bannerService;
		}

		public IActionResult ContactList()
		{
			ViewBag.v1 = "İletişim";
			ViewBag.v2 = "İletişim";
			ViewBag.v3 = "İletişim Listesi";

			var values = _contactService.TGetAll();
			var resultDtos = _mapper.Map<List<ResultContactDto>>(values);
			return View(resultDtos);
		}

		[HttpGet]
		public IActionResult CreateContact()
		{
			ViewBag.v1 = "İletişim";
			ViewBag.v2 = "İletişim";
			ViewBag.v3 = "Yeni İletişim Ekle";

			return View();
		}

		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)
		{
			ViewBag.v1 = "İletişim";
			ViewBag.v2 = "İletişim";
			ViewBag.v3 = "Yeni İletişim Ekle";

			if (!ModelState.IsValid)
			{
				return View(createContactDto);
			}

			var values = _mapper.Map<Contact>(createContactDto);
			_contactService.TAdd(values);
			return RedirectToAction("ContactList", "Contact", new { area = "Admin" });
		}

		[HttpGet]
		public IActionResult UpdateContact(int id)
		{
			ViewBag.v1 = "İletişim";
			ViewBag.v2 = "İletişim";
			ViewBag.v3 = "İletişim Güncelle";

			var values = _contactService.TGetById(id);
			var updateContactDto = _mapper.Map<UpdateContactDto>(values);
			return View(updateContactDto);
		}

		[HttpPost]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			ViewBag.v1 = "İletişim";
			ViewBag.v2 = "İletişim";
			ViewBag.v3 = "İletişim Güncelle";

			if (!ModelState.IsValid)
			{
				return View(updateContactDto);
			}

			var values = _contactService.TGetById(updateContactDto.ContactId);
			_mapper.Map(updateContactDto, values);
			_contactService.TUpdate(values);
			return RedirectToAction("ContactList", "Contact", new { area = "Admin" });
		}

		[HttpPost]
		public IActionResult DeleteContact(int id)
		{
			var values = _contactService.TGetById(id);
			if (values != null)
			{
				_contactService.TDelete(values);
				var deletedContact = _contactService.TGetById(id);
				if (deletedContact == null)
				{
					return Json(new { success = true });
				}
			}
			return Json(new { success = false, message = "Silme işlemi sırasında bir hata oluştu." });
		}
	}
}
