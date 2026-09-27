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

        public DbSet<MasterType> MasterTypes { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                  .HasOne(u => u.Role)
                    .WithMany()
                 .HasForeignKey(u => u.RoleId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolePermissionModule>(
                x =>
                {
                    x.HasOne(rpm => rpm.Role)
                   .WithMany()
                   .HasForeignKey(rpm => rpm.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(rpm => rpm.Permission)
                   .WithMany()
                   .HasForeignKey(rpm => rpm.PermissionId)
                   .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(rpm => rpm.Module)
                     .WithMany()
                     .HasForeignKey(rpm => rpm.ModuleId)
                     .OnDelete(DeleteBehavior.Restrict);
                }

                );

            modelBuilder.Entity<Country>()
                        .HasOne(c => c.Currency)
                        .WithMany(c => c.Countries)
                        .HasForeignKey(c => c.CurrencyId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<State>()
                        .HasOne(s => s.Country)
                        .WithMany(c => c.States)
                        .HasForeignKey(s => s.CountryId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<City>()
                        .HasOne(c => c.State)
                        .WithMany()
                        .HasForeignKey(c => c.StateId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>(
                x =>
                {
                    x.HasOne(c => c.Country)
                        .WithMany(c => c.Companies)
                        .HasForeignKey(c => c.CountryId)
                        .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(c => c.MasterType)
                     .WithMany(m => m.Companies)
                     .HasForeignKey(c => c.MasterTypeId)
                     .OnDelete(DeleteBehavior.Restrict);
                });


            modelBuilder.Entity<Department>(
                x =>
                {
                    x.HasOne(d => d.Company)
                        .WithMany()
                        .HasForeignKey(d => d.CompanyId)
                        .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(d => d.MasterType)
                     .WithMany(m => m.Departments)
                     .HasForeignKey(d => d.MasterTypeId)
                     .OnDelete(DeleteBehavior.Restrict);
                });
                        

            modelBuilder.Entity<Branch>()
                        .HasOne(b => b.Company)
                        .WithMany()
                        .HasForeignKey(b => b.CompanyId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CostCenter>(
                x =>
                {
                    x.HasOne(c => c.Company)
                      .WithMany()
                      .HasForeignKey(c => c.CompanyId)
                      .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(c => c.Department)
                      .WithMany()
                        .HasForeignKey(c => c.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity<ProfitCenter>(
                x =>
                {
                    x.HasOne(p => p.Company)
                     .WithMany()
                     .HasForeignKey(p => p.CompanyId)
                     .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(p => p.Department)
                     .WithMany()
                     .HasForeignKey(p => p.DepartmentId)
                     .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity<Employee>(
                x =>
                {
                    x.HasOne(e => e.User)
                     .WithMany()
                     .HasForeignKey(e => e.UserId)
                     .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(e => e.Role)
                     .WithMany()
                     .HasForeignKey(e => e.RoleId)
                     .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(e => e.Department)
                     .WithMany()
                     .HasForeignKey(e => e.DepartmentId)
                     .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(e => e.Company)
                     .WithMany()
                     .HasForeignKey(e => e.CompanyId)
                     .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(e => e.ReportingManagerEmployee)
                        .WithMany()
                           .HasForeignKey(e => e.ReportingManager)
                          .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity<DocumentType>(
                                   x =>
                                        {
                                               x.HasOne(d => d.CreatedByUser)
                                                .WithMany()
                                                .HasForeignKey(d => d.CreatedBy)
                                                 .OnDelete(DeleteBehavior.Restrict);

                                                   x.HasOne(d => d.ModifiedByUser)
                                                    .WithMany()
                                                    .HasForeignKey(d => d.ModifiedBy)
                                                    .OnDelete(DeleteBehavior.Restrict);
                                         });

            modelBuilder.Entity<Department>(
                                 x =>
                                 {
                                     x.HasOne(d => d.CreatedByUser)
                                        .WithMany()
                                        .HasForeignKey(d => d.CreatedBy)
                                         .OnDelete(DeleteBehavior.Restrict);

                                     x.HasOne(d => d.ModifiedByUser)
                                        .WithMany()
                                        .HasForeignKey(d => d.ModifiedBy)
                                        .OnDelete(DeleteBehavior.Restrict);
                                 });



        }
    }
}
