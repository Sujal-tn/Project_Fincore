using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fincore_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<RolePermissionModule> RolePermissionModules { get; set; }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<ProfitCenter> ProfitCenters { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
