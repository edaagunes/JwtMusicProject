using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(string username, string password)
		{
			var user = await _userManager.FindByNameAsync(username);
			if (user != null)
			{
				var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
				if (result.Succeeded)
				{
					var roles = await _userManager.GetRolesAsync(user);

					if (roles.Contains("Admin"))
						return RedirectToAction("SongList", "Song", new { area = "Admin" });
					else
						return RedirectToAction("SongList", "Song", new { area = "Admin" });
				}
			}

			ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index");
		}
	}
}
