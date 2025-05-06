using JwtMusic.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Controllers
{
	public class UserRegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public UserRegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		//[HttpPost]
		//public async Task<IActionResult> Index(string username, string password)
		//{
		//}
	}
}
