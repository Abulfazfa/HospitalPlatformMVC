namespace HospitalPlatformMVC.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string PatientFullname { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public string Time { get; set; }
        public string ConsultingDate { get; set; }
    }
}
