using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fincore_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<APInvoice> APInvoices { get; set; }
        public DbSet<ARInvoice> ARInvoices { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Asset>(e =>
            {
                e.HasOne(x => x.Vendor)
                 .WithMany(v => v.Assets)
                 .HasForeignKey(x => x.VendorId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Department)
                 .WithMany(d => d.Assets)
                 .HasForeignKey(x => x.DepartmentId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.CapexRequest)
                 .WithMany(c => c.Assets)
                 .HasForeignKey(x => x.CapexRequestId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.PurchaseOrder)
                 .WithMany(p => p.Assets)
                 .HasForeignKey(x => x.PurchaseOrderId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.GRN)
                 .WithMany(g => g.Assets)
                 .HasForeignKey(x => x.GRNId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<APInvoice>(e =>
            {
                e.HasOne(x => x.Vendor)
                 .WithMany(v => v.APInvoices)
                 .HasForeignKey(x => x.VendorId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.PurchaseOrder)
                 .WithMany(p => p.APInvoices)
                 .HasForeignKey(x => x.PurchaseOrderId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.GRN)
                 .WithMany(g => g.APInvoices)
                 .HasForeignKey(x => x.GRNId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.WorkOrder)
                 .WithMany(w => w.APInvoices)
                 .HasForeignKey(x => x.WorkOrderId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ApprovedByUser)
                 .WithMany()
                 .HasForeignKey(x => x.ApprovedBy)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ARInvoice>(e =>
            {
                e.HasOne(x => x.Customer)
                 .WithMany(c => c.ARInvoices)
                 .HasForeignKey(x => x.CustomerId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.RevenueEntry)
                 .WithMany(r => r.ARInvoices)
                 .HasForeignKey(x => x.RevenueEntryId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Payment>(e =>
            {
                e.HasOne(x => x.APInvoice)
                 .WithMany(a => a.Payments)
                 .HasForeignKey(x => x.APInvoiceId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ARInvoice)
                 .WithMany(a => a.Payments)
                 .HasForeignKey(x => x.ARInvoiceId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Vendor)
                 .WithMany(v => v.Payments)
                 .HasForeignKey(x => x.VendorId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Customer)
                 .WithMany(c => c.Payments)
                 .HasForeignKey(x => x.CustomerId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ApprovedByUser)
                 .WithMany()
                 .HasForeignKey(x => x.ApprovedBy)
                 .IsRequired(false)
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
