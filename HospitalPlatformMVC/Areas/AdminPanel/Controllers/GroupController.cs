using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.AdminPanel.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
