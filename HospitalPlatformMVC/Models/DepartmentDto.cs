namespace HospitalPlatformMVC.Models
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DoctorDto> Doctors { get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }

    }
}
