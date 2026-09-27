using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string PasswordHash { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        public DateTime? LastLogin { get; set; }

        public string UserCategory { get; set; }

        public string RefreshToken { get; set; }

        [Required]
        public byte IsActive { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }


        public List<RevenueEntry> RevenueEntriesCreated {  get; set; }
        public List<RevenueEntry> RevenueEntriesModified { get; set; }
        public List<ARInvoice> ARInvoicesCreated { get; set; }     
        public List<ARInvoice> ARInvoicesModified { get; set; }
        public List<AccountMaster> AccountMastersCreated { get; set; }
        public List<AccountMaster> AccountMastersModified { get; set; }
        public List<JournalEntry> JournalEntriesCreated { get; set; }
        public List<JournalEntry> JournalEntriesModified { get; set; }
    }
}
