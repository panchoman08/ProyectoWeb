using ProyectoWeb.Models.supplier;

namespace ProyectoWeb.Repository.SupplierRepositories
{
    public interface ISupplierRepository
    {
        Task<List<SupplierModel>> GetAllAsync();
        Task<(bool success, SupplierModel supplier)> GetByIdAsync(int id);
        Task<(bool success, SupplierModel supplier)> GetByNitAsync(int nit);
        Task<(bool success, SupplierModel supplier)> GetByNameAsync(string name);
        Task<List<SupplierModel>> GetAllThatContainsAsync(string name);
        Task<(bool success, string? message)> CreateAsync(SupplierCreateModel supplier);
        Task<(bool success, string? message)> UpdateAsync(SupplierCreateModel supplier, int id);
        Task<(bool success, string? message)> DeleteAsync(int id);
    }
}
