using AutoMapper;
using JwtMusic.BusinessLayer.Abstract;
using JwtMusic.DtoLayer.AppUserDtos;
using JwtMusic.DtoLayer.BannerDtos;
using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IAppUserService _appUserService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public UserController(IAppUserService appUserService, IMapper mapper, UserManager<AppUser> userManager)
		{
			_appUserService = appUserService;
			_mapper = mapper;
			_userManager = userManager;
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
	}
}
