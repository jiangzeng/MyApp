using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.DataModels
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime RegisterTime { get; set; }
        [Required]
        public DateTime LastLoginTime { get; set; }

    }
}
