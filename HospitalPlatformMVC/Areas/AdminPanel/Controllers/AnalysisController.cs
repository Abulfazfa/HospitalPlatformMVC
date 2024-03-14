using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.AdminPanel.Controllers
{
    public class AnalysisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
