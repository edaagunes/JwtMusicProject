using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.ViewComponents
{
	public class _FooterLayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
