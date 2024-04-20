using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalPlatformMVC.Models
{
    public class RegisterDto
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
