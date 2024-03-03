using HospitalPlatformMVC.Models;
using HospitalPlatformMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalPlatformMVC.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly IDoctorService _doctorService;
        private readonly IGroupService _groupService;
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IDoctorService doctorService, IGroupService groupService, IAppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _groupService = groupService;
            _appointmentService = appointmentService;
        }

        public async Task<IActionResult> Index(int doctorId)
        {
			ResponseDto doctorsList = _doctorService.GetAllDoctorsAsync().Result;
			if (doctorId == 0)
            {
				ResponseDto categoriesList = await _groupService.GetAllDepartmentsAsync();
				
				ViewBag.Doctors = JsonConvert.DeserializeObject<List<DoctorDto>>(Convert.ToString(doctorsList.Result));
				ViewBag.Categories = JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(categoriesList.Result));
			}
            else
            {
                var doctorDto = JsonConvert.DeserializeObject<List<DoctorDto>>(Convert.ToString(doctorsList.Result)).FirstOrDefault(d => d.Id == doctorId);
				ViewBag.Doctors = doctorDto;
				ViewBag.Categories = doctorDto.Branch;
			}
            return View();
        }

        public async Task<IActionResult> MyAppointments()
        {
            // After user registration she/he can open
            return View();
        }
        public async Task<IActionResult> AddAppointment(AppointmentDto appointment)
        {
            try
            {
                DoctorDto doctorDto = GetDoctor(appointment.DoctorId);
                List<AppointmentDto> appointments = new List<AppointmentDto>();
                _appointmentService.CreateAppointmentsAsync(appointment);
                return NoContent();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private DoctorDto GetDoctor(int id)
        {
            ResponseDto response = _doctorService.GetDoctorByIdAsync(id).Result;
            return JsonConvert.DeserializeObject<DoctorDto>(Convert.ToString(response.Result));
        }

    }
}
