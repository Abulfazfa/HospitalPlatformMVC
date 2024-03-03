using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IGroupService _groupService;
		private readonly IDoctorService _doctorService;
		public DepartmentController(IGroupService groupService, IDoctorService doctorService)
		{
			_groupService = groupService;
			_doctorService = doctorService;
		}

		public async Task<IActionResult> Index()
        {
            List<DepartmentDto>? list = new();

            ResponseDto? response = await _groupService.GetAllDepartmentsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

		public async Task<IActionResult> Detail(string name)
		{
			DepartmentDto department = GetDepartment(name);
			ResponseDto doctorsList = _doctorService.GetAllDoctorsAsync().Result;
			var docs = JsonConvert.DeserializeObject<List<DoctorDto>>(Convert.ToString(doctorsList.Result)).Where(d => d.Branch == department.Name);
            ViewBag.Doctors = docs;
			return View(department);
		}

		[HttpPost]
        public async Task<IActionResult> DepartmentCreate(DepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _groupService.CreateDepartmentsAsync(departmentDto);

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


		private DepartmentDto GetDepartment(string name)
		{
			ResponseDto response = _groupService.GetAllDepartmentsAsync().Result;
			return JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(response.Result)).FirstOrDefault(d => d.Name == name);
		}
	}
}
