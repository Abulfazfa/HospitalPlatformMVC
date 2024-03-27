namespace HospitalPlatformMVC.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }

    }
}
