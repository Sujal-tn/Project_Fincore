using Fincore_Project.Data;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fincore_Project.Service
{
    public class AccountMasterService : IAccountMasterService
    {
        ApplicationDbContext data;
        public AccountMasterService(ApplicationDbContext data) 
        {
            this.data=data;
        }

        public async Task AddAccount(AccountMaster account)
        {
             data.AccountMasters.Add(account);
             await data.SaveChangesAsync();
        }

        public async Task DeleteAccount(int id)
        {
           var FindData = data.AccountMasters.Find(id);
            if (FindData != null)
            {
                data.AccountMasters.Remove(FindData);
            }

            await data.SaveChangesAsync();

        }

        public async Task<AccountMaster> GetAccountById(int id)
        {
            var FindData =await data.AccountMasters.Include(x => x.ModifiedByUser).Include(x => x.CreatedByUser).FirstOrDefaultAsync(x => x.AccountId == id);

            return FindData;

        }

        public async Task<List<AccountMaster>> GetAccounts()
        {
            var AllData = await data.AccountMasters.Include(x => x.ModifiedByUser).Include(x => x.CreatedByUser).ToListAsync();

            return AllData;
        }

        public async Task UpdateAccount(AccountMaster account)
        {
            var FindData = data.AccountMasters.Find(account.AccountId);

            if (FindData != null)
            {
                FindData.AccountCode = account.AccountCode;
                FindData.AccountName = account.AccountName;
                FindData.AccountType = account.AccountType;
                FindData.IsActive = account.IsActive;
                FindData.CreatedAt = account.CreatedAt;
                FindData.ModifiedAt = account.ModifiedAt;
                FindData.CreatedBy = account.CreatedBy;
                FindData.ModifiedBy = account.ModifiedBy;
            }

            await data.SaveChangesAsync();
        }
    }
}



