using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Security;

namespace Fincore_Project.Models
{
    public class MasterType
    {
        [Key]
        public int MasterTypeId { get; set; }

        [Required]
        [StringLength(25)]
        public string MasterTypeName { get; set; }

        // Navigation Properties
        public List<Company> Companies { get; set; }
        public List<Department> Departments { get; set; }
        public List<Permission> Permissions { get; set; }
        //public List<Document> Documents { get; set; }
        public List<VendorDocument> Documents { get; set; }
    }
}