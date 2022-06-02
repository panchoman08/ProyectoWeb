using ProyectoWeb.Models.buy_detail;

namespace ProyectoWeb.Repository.BuyDetailRepositories
{
    public interface IBuyDetailRepository
    {

        Task<(bool success, List<BuyDetailModel> buy)> GetByIdAsync(int id);
        Task<(bool success, string? message)> CreateAsync(BuyDetailModel buyDetail);
        Task<(bool success, string? message)> UpdateAsync(int id, BuyDetailModel buyDetail);
        Task<(bool success, string? message)> DeleteAsync(int id);
    }
}
