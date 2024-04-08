using AutoMapper;
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
		private readonly IMapper _mapper;

        public PasientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
		{
			var users = _unitOfWork.AccountService.GetAllUsers().Result;
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
                return Content($"{result.IsCompletedSuccessfully}");
            }
            return Content("There are some problem about pasient's data");
        }

        public IActionResult Update(int id)
        {
            var user = _unitOfWork.UserService.GetByIdAsync(id).Result;
            if (user == null)
                return NotFound();


            // modify this group of code to automapping
            var userDto = _mapper.Map<RegisterDto>(user);

            return View(userDto);
        }

        [HttpPost]
        public IActionResult Update(int id, RegisterDto userDto)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Update), userDto);

            var user = _mapper.Map<User>(userDto);

            if (_unitOfWork.UserService.UpdateAsync(user).Result.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
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
