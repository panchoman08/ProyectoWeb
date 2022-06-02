using ProyectoWeb.Models.customer_category;

namespace ProyectoWeb.Repository.CustomerCatRepositories
{
    public interface ICustomerCatRepository
    {
        Task<List<CustomerCatModel>> GetAllAsync();
        Task<(bool success, CustomerCatModel category)> GetByIdAsync(int id);
        Task<(bool success, CustomerCatModel category)> GetByNameAsync(string id);
        Task<List<CustomerCatModel>> GetAllThatContainsAsync(string name);
        Task<(bool success, string? message)> CreateAsync(CustomerCatCreateModel category);
        Task<(bool success, string? message)> UpdateAsync(int id, CustomerCatCreateModel category);
        Task<(bool success, string? message)> DeleteAsync(int id);
    }
}
