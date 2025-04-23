using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.Controllers
{
	public class LayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
