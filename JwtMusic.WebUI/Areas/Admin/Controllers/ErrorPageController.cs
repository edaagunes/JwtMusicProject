using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ErrorPageController : Controller
	{
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
