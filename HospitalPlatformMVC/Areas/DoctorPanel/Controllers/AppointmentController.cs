using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.DoctorPanel.Controllers
{
	[Area("DoctorPanel")]
	public class AppointmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
