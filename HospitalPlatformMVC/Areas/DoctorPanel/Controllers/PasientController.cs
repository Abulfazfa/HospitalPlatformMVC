using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPlatformMVC.Areas.DoctorPanel.Controllers
{
	[Area("DoctorPanel")]
	public class PasientController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

        public PasientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
		{
			var users = _unitOfWork.UserService.GetAllAsync().Result;
			return View(users);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(RegisterDto registrationRequestDto)
		{
			if (ModelState.IsValid)
			{
				var result = _unitOfWork.AccountService.Register(registrationRequestDto);
                return Content("User add successfully");
            }
            return Content("User add unsuccessfully");
        }
		public IActionResult Search(string search)
		{
			var users = _unitOfWork.UserService.GetAllAsync().Result
		   .Where(p => p.Name.ToLower().Contains(search.ToLower()))
		   .Take(5)
		   .ToList();
			return PartialView("_SearchPartial", users);
		}
	}
}
