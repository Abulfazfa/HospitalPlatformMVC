using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
