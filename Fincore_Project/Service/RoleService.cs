using Fincore_Project.Data;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fincore_Project.Service
{
    public class RoleService : IRoleService
    {
        ApplicationDbContext db;
        public RoleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddRole(Role r)
        {
            await db.Roles.AddAsync(r);
            await db.SaveChangesAsync();
        }

        public async Task DelRole(int id)
        {
            var del = await db.Roles.FindAsync(id);
            if(del!=null)
            {
              db.Roles.Remove(del);
                await db.SaveChangesAsync();
            }

        }

        public async Task<Role> GetRoleById(int id)
        {
           var rol= await db.Roles.FindAsync(id);
            return rol;
        }

        public async Task<List<Role>> GetRoles()
        {
            var rlist = await db.Roles.ToListAsync();
            return rlist;
 
        }

        public async Task UpdateRole(Role role)
        {
            db.Roles.Update(role);
            await db.SaveChangesAsync();
        }
    }
}
