using Fincore_Project.Data;
using Fincore_Project.DTO;
using Fincore_Project.Interface;
using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fincore_Project.Service
{
    public class AuthService : IAuthService
    {
        ApplicationDbContext db;
        public AuthService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<User> LoginUser(LoginDto l)
        {
            var log = db.Users
                .Include(x=>x.Roles).FirstOrDefault(x => x.Email == l.Email && x.PasswordHash == l.Password);
            if(log == null)
            {
                return null;
            }
            if (log.IsActive == 0)
            {
                return null;
            }
            log.LastLogin = DateTime.Now;
            await db.SaveChangesAsync();

            return log;
        }

        public async Task<string> ResgisterUser(RegisterUserDto r)
        {
            var u = await db.Users.FirstOrDefaultAsync(x => x.Email == r.Email);
            if(u!=null)
            {
                return "Email Already Exists";
            }

            var user = new User()
            {
                FullName = r.FullName,
                Email = r.Email,
                PasswordHash = r.Password,
                Phone = r.Phone,
                UserCategory = r.UserCategory,
                RoleId =null,
                IsActive = 1,
                CreatedAt = DateTime.Now,
            };

                  db.Users.Add(user);
            await db.SaveChangesAsync();

            return "User Registered Successfully";

        }

    }
}
