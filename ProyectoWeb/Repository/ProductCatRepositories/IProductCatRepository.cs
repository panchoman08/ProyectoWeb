using ProyectoWeb.Models;

namespace ProyectoWeb.Repository.ProductCatRepositories
{
    public interface IProductCatRepository
    {
        Task<List<ProductCatModel>> GetAllAsync();
        Task<(bool success, ProductCatModel productCat)> GetByIdAsync(int id);
        Task<(bool success, ProductCatModel productCat)> GetByNameAsync(string id);
        Task<List<ProductCatModel>> GetAllThatContainsAsync(string name);
        Task<(bool success, string? message)> CreateAsync(ProductCatCreateModel productCat);
        Task<(bool success, string? message)> UpdateAsync(ProductCatCreateModel productCat, int id);
        Task<(bool success, string? message)> DeleteAsync(int id);
    }
}
