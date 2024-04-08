namespace HospitalPlatformMVC.Models
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
    }
}
