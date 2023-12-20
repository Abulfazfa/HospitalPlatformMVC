using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Controllers
{
	public class OfficeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
