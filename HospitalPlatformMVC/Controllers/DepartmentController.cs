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
        public DepartmentController(IGroupService groupService)
        {
            _groupService = groupService;
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

		public async Task<IActionResult> Detail(int id)
		{
			DepartmentDto department = GetDepartment(id);
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


		private DepartmentDto GetDepartment(int id)
		{
			ResponseDto response = _groupService.GetDepartmentByIdAsync(id).Result;
			return JsonConvert.DeserializeObject<DepartmentDto>(Convert.ToString(response.Result));
		}
	}
}
