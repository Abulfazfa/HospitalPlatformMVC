using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Controllers
{
	public class ServiceController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
