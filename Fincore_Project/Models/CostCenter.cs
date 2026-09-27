namespace Fincore_Project.Models
{
    public class CostCenter
    {
        [Key]
        public int CostCenterId { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        [StringLength(20)]
        public string CostCenterCode { get; set; }

        [Required]
        [StringLength(50)]
        public string CostCenterName { get; set; }

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
