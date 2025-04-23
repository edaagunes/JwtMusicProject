using Microsoft.AspNetCore.Mvc;

namespace JwtMusic.WebUI.Areas.Admin.ViewComponents
{
	public class _ScriptLayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
