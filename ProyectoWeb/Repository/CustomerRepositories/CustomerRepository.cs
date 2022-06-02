using ProyectoWeb.Models.customer;
using ProyectoWeb.Providers.APiFerreteria.customer;

namespace ProyectoWeb.Repository.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerProvider _provider;
        public CustomerRepository()
        {
            _provider = new CustomerProvider();
        }
        public async Task<List<CustomerModel>> GetAllAsync()
        {
            try
            {
                var customers = await _provider.All();

                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<CustomerModel>> GetAllThatContainsAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, CustomerModel customer)> GetByIdAsync(int id)
        {
            try
            {
                var customer = await _provider.GetById(id);

                return (true, customer);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }

        public async Task<(bool success, CustomerModel customer)> GetByNameAsync(string name)
        {
            try
            {
                var customer = await _provider.GetByName(name);

                return (true, customer);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }
        public async Task<(bool success, string? message)> CreateAsync(CustomerCreateModel customer)
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
        public async Task<(bool success, string? message)> UpdateAsync(int id, CustomerCreateModel customer)
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
