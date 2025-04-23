using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.ViewComponents
{
	public class _NavbarLayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
