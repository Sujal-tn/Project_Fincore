using System.ComponentModel.DataAnnotations;

namespace Fincore_Project.Models
{
    public class Module
    {

        [Key]
        public int ModuleId { get; set; }

        [Required]
        [StringLength(100)]
        public string ModuleName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Route { get; set; }

        [Required]
        public byte IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
