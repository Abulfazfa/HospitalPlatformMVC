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
		private readonly UserService _userService;

        public PasientController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
		{
			var users = _userService.GetAllUsersAsync().Result;
			return View(users);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(UserDto userDto)
		{
			if (userDto != null)
			{
				var result = _userService.CreateUsersAsync(userDto);
                return Content("User add successfully");
            }
            return Content("User add unsuccessfully");
        }
		public IActionResult Search(string search)
		{
			var users = _userService.GetAllUsersAsync().Result
		   .Where(p => p.Name.ToLower().Contains(search.ToLower()))
		   .Take(5)
		   .ToList();
			return PartialView("_SearchPartial", users);
		}
	}
}
