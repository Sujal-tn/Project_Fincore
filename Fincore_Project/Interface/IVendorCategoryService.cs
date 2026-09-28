using Fincore_Project.Models;

namespace Fincore_Project.Interface
{
    public interface IVendorCategoryService
    {
        Task AddVendorCategory(VendorCategory v);

        Task AddDocumentType(DocumentType dt);
       

    }
}
