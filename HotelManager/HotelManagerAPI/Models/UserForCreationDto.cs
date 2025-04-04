using System.ComponentModel.DataAnnotations;

namespace HotelManagerAPI.Models
{
    public class UserForCreationDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } = "Receptionist";
    }
}