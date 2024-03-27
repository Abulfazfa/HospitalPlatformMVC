namespace HospitalPlatformMVC.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<string> About { get; set; }
        public string Branch { get; set; }
        public List<string> WorkingTimes { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkingOfficeName { get; set; }
        public double ConsultingFee { get; set; }
        public List<Appointment> Appointments { get; set; }
        public DoctorImage? Image { get; set; }
        public IFormFile? Photo { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
