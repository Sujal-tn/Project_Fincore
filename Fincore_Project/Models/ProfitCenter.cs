using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class ProfitCenter
    {
        [Key]
        public int ProfitCenterId { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        [StringLength(20)]
        public string ProfitCenterCode { get; set; }

        [Required]
        [StringLength(50)]
        public string ProfitCenterName { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public byte IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedBy { get; set; }

        public User CreatedByUser { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public User ModifiedByUser { get; set; }
    }
}
