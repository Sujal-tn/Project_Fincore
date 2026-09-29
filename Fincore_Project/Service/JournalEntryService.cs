using Fincore_Project.Data;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fincore_Project.Service
{
    public class JournalEntryService : IJournalEntryService
    {
        ApplicationDbContext data;

        public JournalEntryService(ApplicationDbContext data)
        {
            this.data = data;

        }

        public async Task AddJournalEntry(JournalEntry entry)
        {
            data.JournalEntries.Add(entry);
            await data.SaveChangesAsync();
        
        }

        public async Task DeleteJournalEntry(int id)
        {
            var findEntry = data.JournalEntries.Find(id);

            if (findEntry != null)
            {
                data.JournalEntries.Remove(findEntry);
            }

            await data.SaveChangesAsync();
        }

        public async Task<List<JournalEntry>> GetJournalEntry()
        {
            var info = await data.JournalEntries.Include(x => x.AccountMaster).ToListAsync();
            return info;
        }

        public async Task<JournalEntry> GetJournalEntryById(int id)
        {
            var FindById = data.JournalEntries.Find(id);
            return FindById;
            
        }

        public Task UpdateJournalEntry(JournalEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
