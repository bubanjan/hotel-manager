using System.ComponentModel.DataAnnotations;

namespace HotelManagerAPI.Entities
{
    public class Guest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

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