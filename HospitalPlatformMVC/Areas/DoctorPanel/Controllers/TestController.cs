using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.DoctorPanel.Controllers
{
    [Area("DoctorPanel")]
    public class TestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public IActionResult Index()
		{
			var tests = _unitOfWork.TestService.GetAllAsync().Result;
			
			return View(tests);
		}

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.RefDoctor = _unitOfWork.DoctorService.GetAllAsync().Result;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Test test)
        {
            _unitOfWork.TestService.CreateAsync(test);
            return View();
        }
    }
}
