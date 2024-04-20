using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
