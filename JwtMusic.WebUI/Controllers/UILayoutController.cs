using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
