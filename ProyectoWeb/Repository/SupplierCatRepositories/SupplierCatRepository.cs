using ProyectoWeb.Models.supplier_category;
using ProyectoWeb.Providers.APiFerreteria.supplier_category;

namespace ProyectoWeb.Repository.SupplierCatRepositories
{
    public class SupplierCatRepository : ISupplierCatRepository
    {

        private readonly SupplierCatProvider _provider;

        public SupplierCatRepository(SupplierCatProvider supplierCat)
        {
            this._provider = supplierCat;
        }

        public async Task<List<SupplierCatModel>> GetAllAsync()
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

        public Task<List<SupplierCatModel>> GetAllThatContainsAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, SupplierCatModel supplierCat)> GetByIdAsync(int id)
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

        public async Task<(bool success, SupplierCatModel supplierCat)> GetByNameAsync(string name)
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
        public async Task<(bool success, string? message)> CreateAsync(SupplierCatCreateModel supplierCat)
        {
            try
            {
                bool success = await _provider.Create(supplierCat);

                return (success, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<(bool success, string? message)> UpdateAsync(SupplierCatCreateModel supplierCat, int id)
        {
            try
            {
                bool success = await _provider.Update(supplierCat, id);

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
