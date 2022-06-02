using ProyectoWeb.Models;
using ProyectoWeb.Providers.APiFerreteria.product_state;

namespace ProyectoWeb.Repository.ProductCatRepositories
{
    public class ProductCatRepository : IProductCatRepository
    {
        private readonly ProductCatProvider _provider;

        public ProductCatRepository(ProductCatProvider provider)
        {
            this._provider = provider;
        }
        public async Task<List<ProductCatModel>> GetAllAsync()
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

        public Task<List<ProductCatModel>> GetAllThatContainsAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, ProductCatModel productCat)> GetByIdAsync(int id)
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

        public async Task<(bool success, ProductCatModel productCat)> GetByNameAsync(string name)
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
        public async Task<(bool success, string? message)> CreateAsync(ProductCatCreateModel productCat)
        {
            try
            {
                bool success = await _provider.Create(productCat);

                return (success, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<(bool success, string? message)> UpdateAsync(ProductCatCreateModel productCat, int id)
        {
            try
            {
                bool success = await _provider.Update(productCat, id);

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
