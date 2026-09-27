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

       
    }
}



