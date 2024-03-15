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
            List<DoctorDto>? list = _doctorService.GetAllDoctorsAsync().Result;

            ViewBag.Categories = _groupService.GetAllDepartmentsAsync().Result;
            return View(list);
        }

        public async Task<IActionResult> Detail(int id)
        {
            DoctorDto? doctor = GetDoctor(id);
            return View(doctor);
        }


        private DoctorDto? GetDoctor(int id)
        {
            return _doctorService.GetDoctorByIdAsync(id).Result;
        }


        [HttpGet]
        public IActionResult GetDoctorsByDepartment(string depName)
        {
            List<DoctorDto> allDoctors = _doctorService.GetAllDoctorsAsync().Result;

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
                updatesTimes = times.ToList();
                if (doctor.Appointments.Count > 0)
                {
                    foreach (var item in doctor.Appointments.Where(a => a.ConsultingDate == date.Value.ToString("yyyy-MM-dd")))
                    {
                        if (times.Contains(item.Time))
                        {
                            updatesTimes.Remove(item.Time);
                        }
                    }
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

