using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.ViewComponents
{
	public class _HeadLayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
