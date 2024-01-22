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


        [HttpGet]
        public IActionResult GetDoctorsByDepartment(string depName)
        {
            ResponseDto response = _doctorService.GetAllDoctorsAsync().Result;
            List<DoctorDto> allDoctors = JsonConvert.DeserializeObject<List<DoctorDto>>(Convert.ToString(response.Result));

            // Filter doctors based on department name
            List<DoctorDto> doctorsInDepartment = allDoctors.Where(d => d.Branch == depName).ToList();
            return Json(doctorsInDepartment);
        }

        [HttpGet]
        public IActionResult GetAvailableTimes(int doctorId, DateTime? date)
        {
            try
            {
                // Call a service method to get available times based on department, doctor, and date
                DoctorDto doctor = GetDoctor(doctorId);
                string[] times = { "8:00 - 9:00", "9:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "12:00 - 13:00" };
                List<string> updatesTimes = new List<string>();

                if (doctor.Appointments != null)
                {
                    foreach (var item in doctor.Appointments.Where(a => a.ConsultingDate == date.ToString()))
                    {
                        if (!times.Contains(item.Time))
                        {
                            updatesTimes.Add(item.Time);
                        }
                    }
                }
                else
                {
                    updatesTimes = times.ToList();
                }
                return Json(updatesTimes);
            } 
            catch (Exception ex)
            {
                return BadRequest("An error occurred while retrieving available times.");
            }
        }


    }
}

