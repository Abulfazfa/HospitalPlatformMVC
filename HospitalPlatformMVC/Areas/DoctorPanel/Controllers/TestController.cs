using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.DoctorPanel.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
