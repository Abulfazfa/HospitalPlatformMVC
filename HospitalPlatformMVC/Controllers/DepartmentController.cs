using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Controllers
{
	public class DepartmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
