using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            List<Group>? list = new();

            list = _unitOfWork.GroupService.GetAllAsync().Result;

            return View(list);
        }

		public async Task<IActionResult> Detail(string name)
		{
			Group department = GetDepartment(name);
			var docs = _unitOfWork.DoctorService.GetAllAsync().Result.Where(d => d.Branch == department.Name);
            ViewBag.Doctors = docs;
			return View(department);
		}

		[HttpPost]
        public async Task<IActionResult> DepartmentCreate(Group departmentDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _unitOfWork.GroupService.CreateAsync(departmentDto);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Department created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(departmentDto);
        }


		private Group GetDepartment(string name)
		{
            return _unitOfWork.GroupService.GetAllAsync().Result.FirstOrDefault(d => d.Name == name);
		}
	}
}
