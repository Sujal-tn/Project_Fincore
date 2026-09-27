using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeCode { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public DateTime? JoiningDate { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [ForeignKey("ReportingManagerEmployee")]
        public int? ReportingManager { get; set; }

        public Employee ReportingManagerEmployee { get; set; }

        [StringLength(25)]
        public string PAN { get; set; }

        public DateTime? CreatedAt { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedBy { get; set; }

        public User CreatedByUser { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }

        public User ModifiedByUser { get; set; }

        [Required]
        public byte IsActive { get; set; }
    }
}