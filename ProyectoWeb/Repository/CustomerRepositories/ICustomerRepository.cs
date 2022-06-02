using ProyectoWeb.Models.customer;

namespace ProyectoWeb.Repository.CustomerRepositories
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetAllAsync();
        Task<(bool success, CustomerModel customer)> GetByIdAsync(int id);
        Task<(bool success, CustomerModel customer)> GetByNameAsync(string id);
        Task<List<CustomerModel>> GetAllThatContainsAsync(string name);
        Task<(bool success, string? message)> CreateAsync(CustomerCreateModel customer);
        Task<(bool success, string? message)> UpdateAsync(int id, CustomerCreateModel customer);
        Task<(bool success, string? message)> DeleteAsync(int id);
    }
}
