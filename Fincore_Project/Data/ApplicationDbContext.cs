using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fincore_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ARInvoice> ARInvoices { get; set; } 
        public DbSet<RevenueEntry> RevenueEntries { get; set; } = null!;
        public DbSet<AccountMaster> AccountMasters { get; set; } = null!;
        public DbSet<JournalEntry> JournalEntries { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Permission> Permissions { get; set; } = null!;
        public DbSet<Module> Modules { get; set; } = null!;
        public DbSet<RolePermissionModule> RolePermissionModules { get; set; } = null!;
        public DbSet<Asset> Assets { get; set; }
        public DbSet<APInvoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<State> States { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;

        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Branch> Branches { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<CostCenter> CostCenters { get; set; } = null!;
        public DbSet<ProfitCenter> ProfitCenters { get; set; } = null!;

        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<MasterType> MasterTypes { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Budget> Budgets { get; set; } = null!;
        public DbSet<BudgetCategory> BudgetCategories { get; set; } = null!;
        public DbSet<BudgetLine> BudgetLines { get; set; } = null!;

        public DbSet<CapexRequest> CapexRequests { get; set; } = null!;
        public DbSet<OpexRequest> OpexRequests { get; set; } = null!;
        public DbSet<ExpenseClaim> ExpenseClaims { get; set; } = null!;

        public DbSet<Vendor> Venders { get; set; }
        public DbSet<VendorCategory> VendorCategory { get; set; }
        public DbSet<VendorDocument> VendorDocument { get; set; }

        public DbSet<DocumentType> DocumentType { get; set; }

        public DbSet<VendorSelection> VendorSelection { get; set; }
        public DbSet<PurchaseRequisition> PurchaseRequisition { get; set; }
        public DbSet<PurchaseRequisitionItem> PurchaseRequisitionItem { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItem { get; set; }

        public DbSet<Quotation> Quotation { get; set; }
        public DbSet<QuotationItem> QuotationItem { get; set; }

        public DbSet<RFQ> RFQ { get; set; }
        public DbSet<RFQVendor> RFQVendor { get; set; }

        public DbSet<WorkOrder> WorkOrder { get; set; }

        public DbSet<GRN> GRN { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Asset>(e =>
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

            modelBuilder.Entity<AssetAssignment>()
                .HasOne(aa => aa.Asset)
                .WithMany(a => a.AssetAssignments)
                .HasForeignKey(aa => aa.AssetId)
                .OnDelete(DeleteBehavior.Restrict);

            // An employee can be assigned multiple assets
            modelBuilder.Entity<AssetAssignment>()
                .HasOne(aa => aa.Employee)
                .WithMany()
                .HasForeignKey(aa => aa.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Store the different locations of an asset
            modelBuilder.Entity<AssetLocation>()
                .HasOne(al => al.Asset)
                .WithMany(a => a.AssetLocations)
                .HasForeignKey(al => al.AssetId)
                .OnDelete(DeleteBehavior.Restrict);

            // An asset can have multiple depreciation records
            modelBuilder.Entity<AssetDepreciation>()
                .HasOne(ad => ad.Asset)
                .WithMany(a => a.AssetDepreciations)
                .HasForeignKey(ad => ad.AssetId)
                .OnDelete(DeleteBehavior.Restrict);

            // An asset can have multiple disposal records as per the current model
            modelBuilder.Entity<AssetDisposal>()
                .HasOne(ad => ad.Asset)
                .WithMany(a => a.AssetDisposals)
                .HasForeignKey(ad => ad.AssetId)
                .OnDelete(DeleteBehavior.Restrict);

            // Store the history of changes made to an asset
            modelBuilder.Entity<AssetHistory>()
                .HasOne(ah => ah.Asset)
                .WithMany(a => a.AssetHistories)
                .HasForeignKey(ah => ah.AssetId)
                .OnDelete(DeleteBehavior.Restrict);

            // Store which user performed an asset history action
            modelBuilder.Entity<AssetHistory>()
                .HasOne(ah => ah.PerformedByUser)
                .WithMany()
                .HasForeignKey(ah => ah.PerformedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<APInvoice>(e =>
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

            modelBuilder.Entity<Payment>(e =>
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


            modelBuilder.Entity<Vendor>(e =>

            {
                e.HasOne(v => v.VendorCategory)
                    .WithMany(vc => vc.Vendors)
                    .HasForeignKey(v => v.VendorCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(v => v.Company)
                    .WithMany(c => c.Vendors)
                    .HasForeignKey(v => v.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);


                modelBuilder.Entity<VendorCategory>()
                    .HasOne(vc => vc.CreatedByUser)
                    .WithMany(u => u.VendorCategoriesCreated)
                    .HasForeignKey(vc => vc.CreatedBy);

                e.HasOne(v => v.CreatedByUser)
                    .WithMany(u => u.VendorsCreated)
                    .HasForeignKey(v => v.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(v => v.ModifiedByUser)
                    .WithMany(u => u.VendorsModified)
                    .HasForeignKey(v => v.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<VendorCategory>(e =>
            {
                e.HasOne(vc => vc.CreatedByUser)
                    .WithMany(u => u.VendorCategoriesCreated)
                    .HasForeignKey(vc => vc.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(vc => vc.ModifiedByUser)
                    .WithMany(u => u.VendorCategoriesModified)
                    .HasForeignKey(vc => vc.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);




                // =====================================================
                // MODULE 2 - ORGANIZATION
                // =====================================================

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
                    .WithMany(s => s.Cities)
                    .HasForeignKey(c => c.StateId)
                    .OnDelete(DeleteBehavior.Restrict);


                modelBuilder.Entity<Company>(x =>
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


                modelBuilder.Entity<Department>(x =>
                {
                    x.HasOne(d => d.Company)
                        .WithMany()
                        .HasForeignKey(d => d.CompanyId)
                        .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(d => d.MasterType)
                        .WithMany(m => m.Departments)
                        .HasForeignKey(d => d.MasterTypeId)
                        .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(d => d.CreatedByUser)
                        .WithMany()
                        .HasForeignKey(d => d.CreatedBy)
                        .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(d => d.ModifiedByUser)
                        .WithMany()
                        .HasForeignKey(d => d.ModifiedBy)
                        .OnDelete(DeleteBehavior.Restrict);
                });


                modelBuilder.Entity<Branch>()
                    .HasOne(b => b.Company)
                    .WithMany()
                    .HasForeignKey(b => b.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);


                modelBuilder.Entity<CostCenter>(x =>
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


                modelBuilder.Entity<ProfitCenter>(x =>
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


                modelBuilder.Entity<Employee>(x =>
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

                    x.HasOne(e => e.CreatedByUser)
                        .WithMany()
                        .HasForeignKey(e => e.CreatedBy)
                        .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(e => e.ModifiedByUser)
                        .WithMany()
                        .HasForeignKey(e => e.ModifiedBy)
                        .OnDelete(DeleteBehavior.Restrict);
                });


                // =====================================================
                // DOCUMENT TYPE AUDIT
                // =====================================================

                modelBuilder.Entity<DocumentType>(x =>
                {
                    modelBuilder.Entity<DocumentType>()
           .HasOne(d => d.CreatedByUser)
           .WithMany(u => u.DocumentTypesCreated)
           .HasForeignKey(d => d.CreatedBy)
           .OnDelete(DeleteBehavior.Restrict);

                    modelBuilder.Entity<DocumentType>()
                        .HasOne(d => d.ModifiedByUser)
                        .WithMany(u => u.DocumentTypesModified)
                        .HasForeignKey(d => d.ModifiedBy)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            });

            modelBuilder.Entity<PurchaseRequisitionItem>(e =>
            {
                e.HasOne(x => x.VendorCategory)
                    .WithMany(vc => vc.PurchaseRequisitionItems)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.PurchaseRequisition)
                    .WithMany(x => x.PurchaseRequisitionItems)
                    .HasForeignKey(x => x.PurchaseRequisitionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<VendorDocument>(e =>
            {
                e.HasOne(x => x.DocumentType)
                    .WithMany(dt => dt.VendorDocuments)
                    .HasForeignKey(x => x.DocumentTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DocumentType>(e =>
            {
                e.HasOne(x => x.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PurchaseRequisition>(e =>
            {
                e.HasOne(x => x.RequestedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.RequestedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ApprovedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ApprovedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RFQ>(e =>
            {
                e.HasOne(x => x.PurchaseRequisition)
                    .WithMany(x => x.RFQs)
                    .HasForeignKey(x => x.PurchaseRequisitionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RFQVendor>(e =>
            {
                e.HasOne(x => x.RFQ)
                    .WithMany(x => x.RFQVendors)
                    .HasForeignKey(x => x.RFQId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.Vendor)
                    .WithMany(x => x.RFQVendors)
                    .HasForeignKey(x => x.VendorId)
                    .OnDelete(DeleteBehavior.Restrict);
            }); 

            modelBuilder.Entity<VendorSelection>(e =>
            {
                e.HasOne(x => x.RFQ)
                    .WithMany(x => x.VendorSelections)
                    .HasForeignKey(x => x.RFQId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.Quotation)
                    .WithMany(x => x.VendorSelections)
                    .HasForeignKey(x => x.QuotationId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.SelectedVendor)
                    .WithMany(x => x.VendorSelections)
                    .HasForeignKey(x => x.SelectedVendorId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.SelectedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.SelectedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PurchaseOrder>(e =>
            {
                e.HasOne(x => x.PurchaseRequisition)
                    .WithMany(x => x.PurchaseOrders)
                    .HasForeignKey(x => x.PurchaseRequisitionId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Quotation)
                    .WithMany(x => x.PurchaseOrders)
                    .HasForeignKey(x => x.QuotationId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.RequestedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.RequestedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ApprovedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ApprovedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PurchaseOrderItem>(e =>
            {
                e.HasOne(x => x.PurchaseRequisitionItem)
                    .WithMany(x => x.PurchaseOrderItems)
                    .HasForeignKey(x => x.PRItemId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<GRN>(e =>
            {
                e.HasOne(x => x.PurchaseOrder)
                    .WithMany(x => x.GRNs)
                    .HasForeignKey(x => x.POId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Vendor)
                    .WithMany(x => x.GRNs)
                    .HasForeignKey(x => x.VendorId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ReceivedByUser)
                    .WithMany(u => u.GRNsReceived)
                    .HasForeignKey(x => x.ReceivedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.QualityCheckedByUser)
                    .WithMany(u => u.GRNsQualityChecked)
                    .HasForeignKey(x => x.QualityCheckedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<WorkOrder>(e =>
            {
                e.HasOne(x => x.OpexRequest)
                    .WithMany(x => x.WorkOrders)
                    .HasForeignKey(x => x.OpexRequestId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Vendor)
                    .WithMany(v => v.WorkOrders)
                    .HasForeignKey(x => x.VendorId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.CreatedByUser)
                    .WithMany(u => u.WorkOrdersCreated)
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasOne(x => x.Role)
                    .WithMany()
                    .HasForeignKey(x => x.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RolePermissionModule>(e =>
            {
                e.HasOne(x => x.Role)
                    .WithMany()
                    .HasForeignKey(x => x.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Permission)
                    .WithMany()
                    .HasForeignKey(x => x.PermissionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Country>(e =>
            {
                e.HasOne(x => x.Currency)
                    .WithMany(x => x.Countries)
                    .HasForeignKey(x => x.CurrencyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<State>(e =>
            {
                e.HasOne(x => x.Country)
                    .WithMany(x => x.States)
                    .HasForeignKey(x => x.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<City>(e =>
            {
                e.HasOne(x => x.State)
                    .WithMany(x => x.Cities)
                    .HasForeignKey(x => x.StateId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Company>(e =>
            {
                e.HasOne(x => x.Country)
                    .WithMany(x => x.Companies)
                    .HasForeignKey(x => x.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.MasterType)
                    .WithMany(x => x.Companies)
                    .HasForeignKey(x => x.MasterTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Department>(e =>
            {
                e.HasOne(x => x.Company)
                    .WithMany(x => x.Departments)
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.MasterType)
                    .WithMany(x => x.Departments)
                    .HasForeignKey(x => x.MasterTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Branch>(e =>
            {
                e.HasOne(x => x.Company)
                    .WithMany()
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<CostCenter>(e =>
            {
                e.HasOne(x => x.Company)
                    .WithMany()
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Department)
                    .WithMany()
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<ProfitCenter>(e =>
            {
                e.HasOne(x => x.Company)
                    .WithMany()
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Department)
                    .WithMany()
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Role)
                    .WithMany()
                    .HasForeignKey(x => x.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Department)
                    .WithMany()
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Company)
                    .WithMany(x => x.Employees)
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ReportingManagerEmployee)
                    .WithMany()
                    .HasForeignKey(x => x.ReportingManager)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Budget>(e =>
            {
                e.HasOne(x => x.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BudgetCategory>(e =>
            {
                e.HasOne(x => x.Department)
                    .WithMany()
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BudgetLine>(e =>
            {
                e.HasOne(x => x.Budget)
                    .WithMany(x => x.BudgetLines)
                    .HasForeignKey(x => x.BudgetId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.BudgetCategory)
                    .WithMany(x => x.BudgetLines)
                    .HasForeignKey(x => x.BudgetCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CapexRequest>(e =>
            {
                e.HasOne(x => x.Department)
                    .WithMany()
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.BudgetLine)
                    .WithMany(x => x.CapexRequests)
                    .HasForeignKey(x => x.BudgetLineId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.RequestedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.RequestedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ApprovedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ApprovedBy)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OpexRequest>(e =>
            {
                e.HasOne(x => x.BudgetLine)
                    .WithMany(x => x.OpexRequests)
                    .HasForeignKey(x => x.BudgetLineId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.RequestedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.RequestedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ApprovedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ApprovedBy)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ExpenseClaim>(e =>
            {
                e.HasOne(x => x.OpexRequest)
                    .WithMany(x => x.ExpenseClaims)
                    .HasForeignKey(x => x.OpexRequestId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ClaimByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ClaimBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ApprovedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.ApprovedBy)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RevenueEntry>(e =>
            {
                e.HasOne(x => x.Department)
                    .WithMany(x => x.RevenueEntry)
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.AccountMaster)
                    .WithMany(x => x.RevenueEntries)
                    .HasForeignKey(x => x.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Customer)
                    .WithMany(x => x.RevenueEntries)
                    .HasForeignKey(x => x.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.CreatedByUser)
                    .WithMany(x => x.RevenueEntriesCreated)
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany(x => x.RevenueEntriesModified)
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ARInvoice>(e =>
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

            modelBuilder.Entity<AccountMaster>(e =>
            {
                e.HasOne(x => x.CreatedByUser)
                    .WithMany(x => x.AccountMastersCreated)
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany(x => x.AccountMastersModified)
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<JournalEntry>(e =>
            {
                e.HasOne(x => x.AccountMaster)
                    .WithMany(x => x.JournalEntries)
                    .HasForeignKey(x => x.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.CreatedByUser)
                    .WithMany(x => x.JournalEntriesCreated)
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.ModifiedByUser)
                    .WithMany(x => x.JournalEntriesModified)
                    .HasForeignKey(x => x.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}