using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class AssetAssignment
    {
        [Key]
        public int AssetAssignmentId { get; set; }


        // Asset
        [Required]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public Asset Asset { get; set; }


        // Employee
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }


        // Assignment Information
        [Required]
        public DateTime AssignedDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }


        // Audit
        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
