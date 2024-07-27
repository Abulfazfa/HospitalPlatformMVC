namespace HospitalPlatformMVC.Models
{
    public class Office
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Tel { get; set; }
        public List<string> WorkingTimes { get; set; }
        public List<Group> Groups { get; set; }
    }
}
