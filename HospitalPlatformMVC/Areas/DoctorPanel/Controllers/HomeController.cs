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
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginDto loginVM)
        {
            if (string.IsNullOrEmpty(loginVM.UsernameOrEmail))
            {
                return View(loginVM);
            }
            var doctors = _unitOfWork.DoctorService.GetAllAsync().Result;
            var doctor = doctors.FirstOrDefault(d => d.CreateDate?.ToString("MM/dd/yyyy HH:mm:ss") == loginVM.UsernameOrEmail);

            if (doctor is null) { return  View(loginVM); }
            else { return RedirectToAction("Index", "Appointment", new { docId = doctor.Id }); }
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
