using System.ComponentModel.DataAnnotations;

namespace Fincore_Project.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(30)]
        public string RoleName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public byte? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
