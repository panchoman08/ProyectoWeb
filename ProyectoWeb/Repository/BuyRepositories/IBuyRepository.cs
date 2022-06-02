using ProyectoWeb.Models.buy;

namespace ProyectoWeb.Repository.BuyRepositories
{
    public interface IBuyRepository
    {
        Task<List<BuyModel>> GetAllAsync();
        Task<(bool success, BuyModel buy)> GetByIdAsync(int id);
        Task<(bool success, BuyModel buy)> GetByNameAsync(string id);
        Task<List<BuyModel>> GetAllThatContainsAsync(string name);
        Task<(bool success, string? message)> CreateAsync(BuyCreateModel buy);
        Task<(bool success, string? message)> UpdateAsync(int id, BuyCreateModel buy);
        Task<(bool success, string? message)> DeleteAsync(int id);
    }
}
