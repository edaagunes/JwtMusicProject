using JwtMusic.EntityLayer.Entities;
using JwtMusic.WebUI.Helpers;
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
		private readonly JwtTokenHelper _jwtTokenHelper;

		public UserLoginController(SignInManager<AppUser> signInManager, JwtTokenHelper jwtTokenHelper)
		{
			_signInManager = signInManager;
			_jwtTokenHelper = jwtTokenHelper;
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
				var user = await _signInManager.UserManager.FindByNameAsync(model.Username);

				// JWT Token'ı oluşturuyoruz
				var token = _jwtTokenHelper.GenerateToken(user);

				TempData["Token"] = token; // geçici olarak token'ı taşı
				return RedirectToAction("SaveTokenAndRedirect", "UserLogin");
			}

			ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> LoginJson(UserLoginViewModel model)
		{
			if (!ModelState.IsValid)
				return Json(new { success = false });

			var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);

			if (result.Succeeded)
			{
				var user = await _signInManager.UserManager.FindByNameAsync(model.Username);
				var token = _jwtTokenHelper.GenerateToken(user);
				return Json(new { success = true, token });
			}

			return Json(new { success = false });
		}


		[HttpGet]
		public IActionResult SaveTokenAndRedirect()
		{
			if (TempData["Token"] != null)
			{
				ViewBag.Token = TempData["Token"].ToString();
			}

			return View(); // Bu view'da token'ı JavaScript ile localStorage'a yaz ve anasayfaya yönlendir
		}


		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "UserLogin");
		}
	}
}

