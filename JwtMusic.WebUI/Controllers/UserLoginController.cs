using JwtMusic.EntityLayer.Entities;
using JwtMusic.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Controllers
{
	[AllowAnonymous]
	public class UserLoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public UserLoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserLoginViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "UILayout");
			}

			ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
			return View(model);
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "UserLogin");
		}
	}
}

