using Fincore_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
            modelBuilder.Entity<Vendor>()
            .HasOne(v => v.VendorCategory)
            .WithMany(vc => vc.Vendors)
            .HasForeignKey(v => v.VendorCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendor>()
            .HasOne(v => v.Company)
            .WithMany(vc => vc.Vendors)
            .HasForeignKey(v => v.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendor>()
            .HasOne(v => v.CreatedByUser)
            .WithMany(u => u.VendorsCreated)
            .HasForeignKey(v => v.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendor>()
                .HasOne(v => v.ModifiedByUser)
                .WithMany(u => u.VendorsModified)
                .HasForeignKey(v => v.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseRequisitionItem>()
            .HasOne(p => p.VendorCategory)
            .WithMany(vc => vc.PurchaseRequisitionItems)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VendorDocument>()
             .HasOne(d => d.DocumentType)
             .WithMany(dt => dt.VendorDocuments)
             .HasForeignKey(d => d.DocumentTypeId)
             .OnDelete(DeleteBehavior.Restrict);

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


            modelBuilder.Entity<PurchaseRequisition>()
            .HasOne(x => x.RequestedByUser)
            .WithMany(u => u.PurchaseRequisitionsRequested)
            .HasForeignKey(x => x.RequestedBy)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseRequisition>()
                .HasOne(x => x.ApprovedByUser)
                .WithMany(u => u.PurchaseRequisitionsApproved)
                .HasForeignKey(x => x.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseRequisition>()
                .HasOne(x => x.CreatedByUser)
                .WithMany(u => u.PurchaseRequisitionsCreated)
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseRequisition>()
                .HasOne(x => x.ModifiedByUser)
                .WithMany(u => u.PurchaseRequisitionsModified)
                .HasForeignKey(x => x.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseRequisitionItem>()
            .HasOne(x => x.PurchaseRequisition)
            .WithMany(x => x.PurchaseRequisitionItems)
            .HasForeignKey(x => x.PurchaseRequisitionId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RFQ>()
             .HasOne(r => r.PurchaseRequisition)
             .WithMany(pr => pr.RFQs)
             .HasForeignKey(r => r.PurchaseRequisitionId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQVendor>()
            .HasOne(x => x.RFQ)
            .WithMany(r => r.RFQVendors)
            .HasForeignKey(x => x.RFQId)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<RFQVendor>()
             .HasOne(x => x.Vendor)
             .WithMany(v => v.RFQVendors)
             .HasForeignKey(x => x.VendorId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VendorSelection>()
            .HasOne(x => x.RFQ)
            .WithMany(r => r.VendorSelections)
            .HasForeignKey(x => x.RFQId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VendorSelection>()
            .HasOne(x => x.Quotation)
            .WithMany(q => q.VendorSelections)
            .HasForeignKey(x => x.QuotationId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<VendorSelection>()
    .HasOne(x => x.SelectedVendor)
    .WithMany(v => v.VendorSelections)
    .HasForeignKey(x => x.SelectedVendorId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrder>()
    .HasOne(x => x.PurchaseRequisition)
    .WithMany(pr => pr.PurchaseOrders)
    .HasForeignKey(x => x.PurchaseRequisitionId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrder>()
     .HasOne(x => x.Quotation)
     .WithMany(q => q.PurchaseOrders)
     .HasForeignKey(x => x.QuotationId)
     .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrder>()
    .HasOne(x => x.RequestedByUser)
    .WithMany(u => u.PurchaseOrdersRequested)
    .HasForeignKey(x => x.RequestedBy)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(x => x.ApprovedByUser)
                .WithMany(u => u.PurchaseOrdersApproved)
                .HasForeignKey(x => x.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(x => x.CreatedByUser)
                .WithMany(u => u.PurchaseOrdersCreated)
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(x => x.ModifiedByUser)
                .WithMany(u => u.PurchaseOrdersModified)
                .HasForeignKey(x => x.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrderItem>()
       .HasOne(x => x.PurchaseRequisitionItem)
       .WithMany(pri => pri.PurchaseOrderItems)
       .HasForeignKey(x => x.PRItemId)
       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GRN>()
    .HasOne(x => x.PurchaseOrder)
    .WithMany(x => x.GRNs)
    .HasForeignKey(x => x.POId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GRN>()
    .HasOne(x => x.Vendor)
    .WithMany()
    .HasForeignKey(x => x.VendorId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GRN>()
    .HasOne(x => x.ReceivedByUser)
    .WithMany(u => u.GRNsReceived)
    .HasForeignKey(x => x.ReceivedBy)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GRN>()
                .HasOne(x => x.QualityCheckedByUser)
                .WithMany(u => u.GRNsQualityChecked)
                .HasForeignKey(x => x.QualityCheckedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkOrder>()
           .HasOne(x => x.OpexRequest)
           .WithMany()
           .HasForeignKey(x => x.OpexRequestId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkOrder>()
    .HasOne(x => x.Vendor)
    .WithMany()
    .HasForeignKey(x => x.VendorId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkOrder>()
    .HasOne(x => x.CreatedByUser)
    .WithMany(u => u.WorkOrdersCreated)
    .HasForeignKey(x => x.CreatedBy)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VendorSelection>()
    .HasOne(x => x.SelectedByUser)
    .WithMany(u => u.VendorSelectionsSelected)
    .HasForeignKey(x => x.SelectedBy)
    .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PurchaseOrder>()
    .HasOne(x => x.PurchaseRequisition)
    .WithMany(pr => pr.PurchaseOrders)
    .HasForeignKey(x => x.PurchaseRequisitionId)
    .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PurchaseOrderItem>()
    .HasOne(x => x.PurchaseRequisitionItem)
    .WithMany(pri => pri.PurchaseOrderItems)
    .HasForeignKey(x => x.PRItemId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GRN>()
    .HasOne(x => x.Vendor)
    .WithMany(v => v.GRNs)
    .HasForeignKey(x => x.VendorId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkOrder>()
    .HasOne(x => x.Vendor)
    .WithMany(v => v.WorkOrders)
    .HasForeignKey(x => x.VendorId)
    .OnDelete(DeleteBehavior.Restrict);


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
