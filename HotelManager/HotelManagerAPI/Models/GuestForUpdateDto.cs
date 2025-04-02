using System.ComponentModel.DataAnnotations;

namespace HotelManagerAPI.Models
{
    public class GuestForUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Telephone { get; set; }
    }
}
