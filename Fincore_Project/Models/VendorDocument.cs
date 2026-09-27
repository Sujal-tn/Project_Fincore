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
        public int VendorId { get; set; }

        [ForeignKey("Vendor")]
        public Vendor Vendor { get; set; }

        [Required]
        public int DocumentTypeId { get; set; }

        [ForeignKey(("DocumentType"))]
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
    }
}
