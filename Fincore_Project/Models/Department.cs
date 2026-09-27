using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        [StringLength(30)]
        public string DepartmentName { get; set; }

        [Required]
        [StringLength(30)]
        public string DepartmentCode { get; set; }

        [ForeignKey("MasterType")]
        public int? MasterTypeId { get; set; }

        public MasterType MasterType { get; set; }

        [Required]
        public byte IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }

        public User CreatedByUser { get; set; }

        [Required]
        [ForeignKey("ModifiedByUser")]
        public int ModifiedBy { get; set; }

        public User ModifiedByUser { get; set; }
        public List<RevenueEntry> RevenueEntry {  get; set; }
        public List<Asset> Assets { get; set; }
    }
}