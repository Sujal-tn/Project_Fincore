using Fincore_Project.Models;

namespace Fincore_Project.Interface
{
    public interface IVendorCategoryService
    {
        Task AddVendor(Vendor v);
        Task AddVendorCategory(VendorCategory v);
        //Task <List<VendorCategory>> FetchVendorCategory();

        Task AddDocumentType(DocumentType dt);

        Task AddDocument(VendorDocument vd, IFormFile documentFile);

        Task<List<Vendor>> getVendors();

        Task<List<Vendor>> FetchVendors();
        Task<List<User>> getUsers();
        Task<List<DocumentType>> getDocumentType();

        Task<List<MasterType>> getMasterType();

        Task<List<VendorCategory>> getVendorCategory();

        Task<List<Company>> getCompany();

        Task DelVendor(int id);

        Task<Vendor> getVendorById(int id);

        Task UpdateVendor(Vendor v);

        Task DelVendorCategory(int id);

        Task<VendorCategory> getVendorCategoryById(int id);

        Task UpdateVendorCategory(VendorCategory v);

        Task<List<VendorDocument>> FetchVendorDocument();

        Task DelVendorDocument(int id);

        Task<VendorDocument> getVendorDocumentById(int id);

        Task UpdateVendorDocument(VendorDocument v);

    }
}
