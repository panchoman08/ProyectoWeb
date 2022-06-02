using ProyectoWeb.Models.product_measure;

namespace ProyectoWeb.Repository.ProductMeasureRepository
{
    public interface IProductMeasureRepository
    {
        Task<List<ProductMeasureModel>> GetAllAsync();
        Task<(bool success, ProductMeasureModel measure)> GetByIdAsync(int id);
        Task<(bool success, ProductMeasureModel measure)> GetByNameAsync(string id);
        Task<List<ProductMeasureModel>> GetAllThatContainsAsync(string name);
        Task<(bool success, string? message)> CreateAsync(ProductMeasureCreateModel measure);
        Task<(bool success, string? message)> UpdateAsync(ProductMeasureCreateModel measure, int id);
        Task<(bool success, string? message)> DeleteAsync(int id);
    }
}
