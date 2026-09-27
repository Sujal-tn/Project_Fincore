using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fincore_Project.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }

        [Required]
        [StringLength(20)]
        public string DocumentCategory { get; set; }

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

        // Navigation Properties
       
        public List<VendorDocument> VendorDocuments { get; set; } 
    }
}
