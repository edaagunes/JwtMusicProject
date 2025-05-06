using JwtMusic.DataAccessLayer.Context;
using JwtMusic.EntityLayer.Entities;
using JwtMusic.WebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JwtMusic.WebUI.Controllers
{
	public class UserRegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly JwtMusicContext _context;

		public UserRegisterController(UserManager<AppUser> userManager, JwtMusicContext context)
		{
			_userManager = userManager;
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var packages = _context.Packages
											.Select(x => new SelectListItem
											{
												Value = x.PackageId.ToString(),
												Text = x.Name
											}).ToList();

			ViewBag.Packages = packages;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserRegisterViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var user = new AppUser
			{
				UserName = model.Username,
				PackageId = model.PackageId,
				FullName = model.FullName
			};

			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				return RedirectToAction("Login", "UserLogin");
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}

			return View(model);
		}
	}
}
