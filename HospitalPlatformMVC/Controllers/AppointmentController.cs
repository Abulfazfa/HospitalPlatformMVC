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
			if (doctorId == 0)
            {
				
				ViewBag.Doctors = _doctorService.GetAllDoctorsAsync().Result;
				ViewBag.Categories = _groupService.GetAllDepartmentsAsync().Result;
			}
            else
            {
                var doctorDto = _doctorService.GetDoctorByIdAsync(doctorId).Result;
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

        private DoctorDto? GetDoctor(int id)
        {
            return _doctorService.GetDoctorByIdAsync(id).Result;
        }

    }
}
