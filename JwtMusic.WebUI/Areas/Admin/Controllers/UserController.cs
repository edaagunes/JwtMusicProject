using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.AppUserDtos;
using JwtMusic.DtoLayer.BannerDtos;
using JwtMusic.DtoLayer.EventDtos;
using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IAppUserService _appUserService;
		private readonly IPackageService _packageService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public UserController(IAppUserService appUserService, IMapper mapper, UserManager<AppUser> userManager, IPackageService packageService)
		{
			_appUserService = appUserService;
			_mapper = mapper;
			_userManager = userManager;
			_packageService = packageService;
		}

		public async Task<IActionResult> UserList()
		{
			ViewBag.v1 = "Kullanıcılar";
			ViewBag.v2 = "Kullanıcılar";
			ViewBag.v3 = "Kullanıcı Listesi";

			var users = _appUserService.TGetPackageNameWithUserList();

			var filteredUsers = new List<AppUser>();
			foreach (var user in users)
			{
				var roles = _userManager.GetRolesAsync(user).Result; 
				if (roles.Contains("User"))
				{
					filteredUsers.Add(user);
				}
			}

			var resultDtos = filteredUsers.Select(user => new ResultAppUserDto
			{
				Id = user.Id,
				FullName = user.FullName,
				PackageId = user.PackageId,
				PackageName = user.Package?.Name ?? "Paket Yok"
			}).ToList();
			return View(resultDtos);
		}

		[HttpPost]
		public IActionResult DeleteBanner(int id)
		{
			var values = _appUserService.TGetById(id);
			if (values != null)
			{
				_appUserService.TDelete(values);
				var deletedUser = _appUserService.TGetById(id);
				if (deletedUser == null)
				{
					return Json(new { success = true });
				}
			}
			return Json(new { success = false, message = "Silme işlemi sırasında bir hata oluştu." });
		}

		[HttpGet]
		public IActionResult UpdateUser(int id)
		{
			ViewBag.v1 = "Kullanıcı";
			ViewBag.v2 = "Kullanıcı";
			ViewBag.v3 = "Kullanıcıyı Güncelle";

			var values = _appUserService.TGetById(id);
			var updateUserDto=_mapper.Map<UpdateAppUserDto>(values);

			var packages = _packageService.TGetAll();
			ViewBag.Packages = new SelectList(packages, "PackageId", "Name");

			return View(updateUserDto);
		}

		[HttpPost]
		public IActionResult UpdateUser(UpdateAppUserDto updateAppUserDto)
		{
			ViewBag.v1 = "Kullanıcı";
			ViewBag.v2 = "Kullanıcı";
			ViewBag.v3 = "Kullanıcıyı Güncelle";

			var packages = _packageService.TGetAll();
			ViewBag.Packages = new SelectList(packages, "PackageId", "Name");

			if (!ModelState.IsValid)
			{
				return View(updateAppUserDto);
			}

			var values = _appUserService.TGetById(updateAppUserDto.Id);
			_mapper.Map(updateAppUserDto, values);
			_appUserService.TUpdate(values);

			return RedirectToAction("UserList", "User", new { area = "Admin" });
		}
	}
}
