namespace HospitalPlatformMVC.Models
{
    public class Group
    {
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }

        public Group()
        {
            Doctors = new List<Doctor>();
        }

    }
}
