using HospitalPlatformMVC.Helper;
using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Areas.DoctorPanel.Controllers
{
    [Area("DoctorPanel")]
    public class HomeController : Controller
    {
        private readonly IDoctorService _doctorService;

        public HomeController(IDoctorService doctorService)
        {
			_doctorService = doctorService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginDto loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            int docId = int.Parse(loginVM.UsernameOrEmail);
            

			return RedirectToAction("Index", "Appointment", new { docId = docId });
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
