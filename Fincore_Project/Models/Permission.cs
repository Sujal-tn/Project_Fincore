using System.ComponentModel.DataAnnotations;

namespace Fincore_Project.Models
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        [StringLength(50)]
        public string PermissionName { get; set; }

        [Required]
        public byte IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}