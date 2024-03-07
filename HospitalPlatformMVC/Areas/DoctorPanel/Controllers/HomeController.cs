using HospitalPlatformMVC.Helper;
using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.DoctorPanel.Controllers
{
    [Area("DoctorPanel")]
    public class HomeController : Controller
    {
        //private readonly IAccountService _accountService;

        public HomeController(/*IAccountService accountService*/)
        {
            //_accountService = accountService;
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

            return View(loginVM);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
