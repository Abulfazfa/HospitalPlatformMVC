using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
