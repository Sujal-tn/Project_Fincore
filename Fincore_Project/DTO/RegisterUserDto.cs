using System.ComponentModel.DataAnnotations;

namespace Fincore_Project.DTO
{
    public class RegisterUserDto
    {
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        public string UserCategory { get; set; }
    }
}
