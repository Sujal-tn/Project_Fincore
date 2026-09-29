using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Models
{
    public class JournalEntry
    {
        [Key]
        public int JournalEntryId { get; set; }

        [Required]
        [ForeignKey("AccountMaster")]
        public int AccountId { get; set; }
        public AccountMaster AccountMaster { get; set; }


        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DebitAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CreditAmount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
         
        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }


        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }
        public User? ModifiedByUser { get; set; }
    }
}
