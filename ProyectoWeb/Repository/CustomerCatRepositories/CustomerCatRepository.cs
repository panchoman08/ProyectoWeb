using ProyectoWeb.Models.customer_category;
using ProyectoWeb.Providers.APiFerreteria.customer_category;

namespace ProyectoWeb.Repository.CustomerCatRepositories
{
    public class CustomerCatRepository : ICustomerCatRepository
    {
        private readonly CustomerCatProvider _provider;
        public CustomerCatRepository()
        {
            _provider = new CustomerCatProvider();
        }

        public async Task<List<CustomerCatModel>> GetAllAsync()
        {
            try
            {
                var categories = await _provider.All();

                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<CustomerCatModel>> GetAllThatContainsAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, CustomerCatModel category)> GetByIdAsync(int id)
        {
            try
            {
                var category = await _provider.GetById(id);

                return (true, category);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }

        public async Task<(bool success, CustomerCatModel category)> GetByNameAsync(string name)
        {
            try
            {
                var category = await _provider.GetByName(name);

                return (true, category);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }
        public async Task<(bool success, string? message)> CreateAsync(CustomerCatCreateModel customer)
        {
            try
            {
                bool success = await _provider.Create(customer);

                return (success, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<(bool success, string? message)> UpdateAsync(int id, CustomerCatCreateModel customer)
        {
            try
            {
                bool success = await _provider.Update(customer, id);

                return (success, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<(bool success, string? message)> DeleteAsync(int id)
        {
            try
            {
                bool success = await _provider.Delete(id);

                return (success, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
