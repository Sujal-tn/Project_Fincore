namespace Fincore_Project.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        [StringLength(20)]
        public string BranchCode { get; set; }

        [Required]
        [StringLength(50)]
        public string BranchName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(20)]
        public string ContactNumber { get; set; }

        [StringLength(40)]
        public string ContactEmail { get; set; }

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
