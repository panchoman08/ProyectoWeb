using ProyectoWeb.Models;

namespace ProyectoWeb.Repository.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllAsync();
        Task<(bool success, ProductModel product)> GetByIdAsync(int id);
        Task<ProductModel> GetBySkuAsync(int id);
        Task<ProductModel> GetByNameAsync(string id);
        Task<List<ProductModel>> GetAllThatContainsAsync(string name);
        Task<(bool success, string? message)> CreateAsync(ProductCreate product);

        Task<(bool success, string? message)> UpdateAsync(ProductCreate product, int id);
        Task<(bool success, string? message)> DeleteAsync(int id);
       
    }
}
