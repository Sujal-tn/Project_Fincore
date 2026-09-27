using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fincore_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<ARInvoice> ARInvoices { get; set; }

        public DbSet<RevenueEntry> RevenueEntries { get; set; }

        public DbSet<AccountMaster> AccountMasters { get; set; }

        public DbSet<JournalEntry> JournalEntries { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //Revenue Mappling
            builder.Entity<RevenueEntry>(e =>
            {
                e.HasOne(x => x.Department)
                .WithMany(x=> x.RevenueEntry)
                .HasForeignKey(x=>x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<RevenueEntry>(e =>
            {
                e.HasOne(x => x.AccountMaster)
                 .WithMany(x => x.RevenueEntries)
                 .HasForeignKey(x => x.AccountId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<RevenueEntry>(e =>
            {
                e.HasOne(x => x.Customer)
                 .WithMany(x => x.RevenueEntries)
                 .HasForeignKey(x => x.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<RevenueEntry>(e =>
            {
                e.HasOne(x => x.CreatedByUser)
                 .WithMany(x => x.RevenueEntriesCreated)
                 .HasForeignKey(x => x.CreatedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<RevenueEntry>(e =>
            {
                e.HasOne(x => x.ModifiedByUser)
                 .WithMany(x => x.RevenueEntriesModified)
                 .HasForeignKey(x => x.ModifiedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });


            //ARInvoice Mappling

            builder.Entity<ARInvoice>(e =>
            {
                e.HasOne(x => x.Customer)
                .WithMany(x => x.ARInvoices)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ARInvoice>(e =>
            {
                e.HasOne(x => x.RevenueEntry)
                 .WithMany(x => x.ARInvoices)
                 .HasForeignKey(x => x.RevenueEntryId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ARInvoice>(e =>
            {
                e.HasOne(x => x.CreatedByUser)
                 .WithMany(x => x.ARInvoicesCreated)
                 .HasForeignKey(x => x.CreatedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ARInvoice>(e =>
            {
                e.HasOne(x => x.ModifiedByUser)
                 .WithMany(x => x.ARInvoicesModified)
                 .HasForeignKey(x => x.ModifiedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });


            //AccountMaster Mappling

            builder.Entity<AccountMaster>(e =>
            {
                e.HasOne(x => x.CreatedByUser)
                 .WithMany(x => x.AccountMastersCreated)
                 .HasForeignKey(x => x.CreatedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<AccountMaster>(e =>
            {
                e.HasOne(x => x.ModifiedByUser)
                 .WithMany(x => x.AccountMastersModified)
                 .HasForeignKey(x => x.ModifiedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            //JournalEntry Mappling

            builder.Entity<JournalEntry>(e =>
            {
                e.HasOne(x => x.AccountMaster)
                 .WithMany(x => x.JournalEntries)
                 .HasForeignKey(x => x.AccountId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<JournalEntry>(e =>
            {
                e.HasOne(x => x.CreatedByUser)
                 .WithMany(x => x.JournalEntriesCreated)
                 .HasForeignKey(x => x.CreatedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<JournalEntry>(e =>
            {
                e.HasOne(x => x.ModifiedByUser)
                 .WithMany(x => x.JournalEntriesModified)
                 .HasForeignKey(x => x.ModifiedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });
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
