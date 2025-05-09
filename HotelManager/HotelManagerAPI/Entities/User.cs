﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagerAPI.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
