using ProyectoWeb.Models.supplier_category;

namespace ProyectoWeb.Repository.SupplierCatRepositories
{
    public interface ISupplierCatRepository
    {
        Task<List<SupplierCatModel>> GetAllAsync();
        Task<(bool success, SupplierCatModel supplierCat)> GetByIdAsync(int id);
        Task<(bool success, SupplierCatModel supplierCat)> GetByNameAsync(string id);
        Task<List<SupplierCatModel>> GetAllThatContainsAsync(string name);
        Task<(bool success, string? message)> CreateAsync(SupplierCatCreateModel supplierCat);
        Task<(bool success, string? message)> UpdateAsync(SupplierCatCreateModel supplierCat, int id);
        Task<(bool success, string? message)> DeleteAsync(int id);
    }
}
