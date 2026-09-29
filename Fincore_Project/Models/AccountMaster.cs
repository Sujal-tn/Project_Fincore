using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class AccountMaster
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [StringLength(30)]
        public string AccountCode { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        public string AccountType { get; set; }

        public byte IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        
        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }


        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }
        public User? ModifiedByUser { get; set; }

        //Navigation 

        public List<RevenueEntry> RevenueEntries { get; set; }
        public List<JournalEntry> JournalEntries { get; set; }
    }
}

