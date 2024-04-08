using AutoMapper;
using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.DoctorPanel.Controllers
{
    [Area("DoctorPanel")]
    public class TestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TestController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            if (ModelState.IsValid)
            {
                var result = _unitOfWork.TestService.CreateAsync(test);
                return Content($"{result.IsCompletedSuccessfully}");
            }
            return Content("There are some problem about pasient's data");
        }

		public IActionResult Update()
		{
			ViewBag.RefDoctor = _unitOfWork.DoctorService.GetAllAsync().Result;
			return View();
		}

		[HttpPost]
		public IActionResult Update(Test test)
		{
			_unitOfWork.TestService.UpdateAsync(test);
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Update), test);

            if (_unitOfWork.TestService.UpdateAsync(test).Result.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }
	}
}
