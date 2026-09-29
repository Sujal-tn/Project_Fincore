using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Xml.Linq;

namespace Fincore_Project.Models
{
    public class VendorDocument
    {
        [Key]
        public int VendorDocumentId { get; set; }

        [Required]
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("DocumentType")]
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }

        [Required]
        [StringLength(100)]
        public string FileName { get; set; }

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; }

        [StringLength(100)]
        public string FileType { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        [ForeignKey("MasterType")]
        public int? MasterTypeId { get; set; }
        public MasterType MasterType { get; set; }


    }
}
