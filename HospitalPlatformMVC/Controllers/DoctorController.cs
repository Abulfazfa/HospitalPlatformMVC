using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Controllers
{
	public class DoctorController : Controller
	{
        private readonly IDoctorService _doctorService;
        private readonly IGroupService _groupService;
        public DoctorController(IDoctorService doctorService, IGroupService groupService)
        {
            _doctorService = doctorService;
            _groupService = groupService;
        }

        public async Task<IActionResult> Index()
		{
            List<DoctorDto>? list = new();

            ResponseDto? response = await _doctorService.GetAllDoctorsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DoctorDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            var groupDto = _groupService.GetAllDepartmentsAsync().Result;
            ViewBag.Categories = JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(groupDto.Result)); 
            return View(list);
        }

        public async Task<IActionResult> Detail(int id)
        {
            DoctorDto doctor = GetDoctor(id);
            return View(doctor);
        }

		public async Task<IActionResult> Appointment(DoctorDto doctorDto)
		{
            ResponseDto categoriesList = await _groupService.GetAllDepartmentsAsync();
            ResponseDto doctorsList = _doctorService.GetAllDoctorsAsync().Result;
            ViewBag.Doctors = JsonConvert.DeserializeObject<List<DoctorDto>>(Convert.ToString(doctorsList.Result));
            ViewBag.Categories = JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(categoriesList.Result));
            return View(doctorDto);
		}

		public async Task<IActionResult> DoctorCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoctorCreate(DoctorDto doctorDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _doctorService.CreateDoctorsAsync(doctorDto);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Doctor created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(doctorDto);
        }

        private DoctorDto GetDoctor(int id)
        {
            ResponseDto response = _doctorService.GetDoctorByIdAsync(id).Result;
            return JsonConvert.DeserializeObject<DoctorDto>(Convert.ToString(response.Result));
        }

    }
}

