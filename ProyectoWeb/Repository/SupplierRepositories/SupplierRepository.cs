using ProyectoWeb.Models.supplier;
using ProyectoWeb.Providers.APiFerreteria.supplier;

namespace ProyectoWeb.Repository.SupplierRepositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SupplierProvider _provider;

        public SupplierRepository(SupplierProvider provider)
        {
            this._provider = provider;
        }


        public async Task<List<SupplierModel>> GetAllAsync()
        {
            try
            {
                var suppliers = await _provider.All();

                return suppliers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<List<SupplierModel>> GetAllThatContainsAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, SupplierModel supplier)> GetByIdAsync(int id)
        {
            try
            {
                var supplier = await _provider.GetById(id);

                return (true, supplier);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }

        public Task<(bool success, SupplierModel supplier)> GetByNitAsync(int nit)
        {
            throw new NotImplementedException();
        }
        public async Task<(bool success, SupplierModel supplier)> GetByNameAsync(string name)
        {
            try
            {
                var supplier = await _provider.GetByName(name);

                return (true, supplier);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }

        public async Task<(bool success, string? message)> CreateAsync(SupplierCreateModel supplier)
        {
            try
            {
                bool create = await _provider.Create(supplier);

                return (create, "");
            }
            catch(Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<(bool success, string? message)> UpdateAsync(SupplierCreateModel supplier, int id)
        {
            try
            {
                bool update = await _provider.Update(supplier, id);

                return (update, "");
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
                bool delete = await _provider.Delete(id);

                return (delete, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message); 
            }
        }
    }
}
