using Fincore_Project.Models;

namespace Fincore_Project.Interface
{
    public interface IAccountMasterService
    {
        public Task AddAccount(AccountMaster account);
        public Task<List<AccountMasterListDTO>> GetAccounts();
        public Task DeleteAccount(int id);
        public Task<AccountMaster> GetAccountById(int id);
        public Task UpdateAccount(AccountMaster account);

       
    }
}
