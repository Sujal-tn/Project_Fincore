using Fincore_Project.Models;

namespace Fincore_Project.Interface
{
    public interface IJournalEntryService
    {
        public Task AddJournalEntry(JournalEntry entry);

        public Task<List<JournalEntry>> GetJournalEntry();

        public Task DeleteJournalEntry(int id);
        public  Task<JournalEntry> GetJournalEntryById(int id);

        public Task UpdateJournalEntry(JournalEntry entry);


    }
}
