using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.ViewComponents.UILayout
{
	public class _FooterComponentPartial:ViewComponent
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public _FooterComponentPartial(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke()
		{
			var values = _contactService.TGetAll();
			var result = _mapper.Map<List<ResultContactDto>>(values);
			return View(result);
		}
	}
}
