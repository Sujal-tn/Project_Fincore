using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class RolePermissionModule
    {
        [Key]
        public int RolePermissionModuleId { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        [Required]
        [ForeignKey("Permission")]
        public int PermissionId { get; set; }

        public Permission Permission { get; set; }

        [Required]
        [ForeignKey("Module")]
        public int ModuleId { get; set; }

        public Module Module { get; set; }

        [Required]
        public byte IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
