using ProyectoWeb.Models;
using ProyectoWeb.Models.ErrorModel;
using ProyectoWeb.Providers.APiFerreteria.product;

namespace ProyectoWeb.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductProvider _provider;
        public ProductRepository(ProductProvider provider)
        {
            this._provider = provider;
        }

        public async Task<List<ProductModel>> GetAllAsync() => await _provider.AllProducts();

        public async Task<(bool success, ProductModel product)> GetByIdAsync(int id)
        {
            try
            {
                var product = await _provider.GetProductById(id);

                return (true, product);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }
        public async Task<ProductModel> GetBySkuAsync(int id) => await _provider.GetProductById(id);
        public async Task<ProductModel> GetByNameAsync(string name) => throw new NotImplementedException();
        public async Task<List<ProductModel>> GetAllThatContainsAsync(string id) => throw new NotImplementedException();
        public async Task<(bool success, string? message)> CreateAsync(ProductCreate product)
        {
            try
            {
                var isCreated = await _provider.Create(product);

                return (isCreated, "Ok");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<(bool success, string? message)> UpdateAsync(ProductCreate product, int id)
        {
            try
            {
                var update = await _provider.Update(product, id);
                return (update, "");
            }
            catch(Exception ex)
            {
                return (false, $"{ex.Message}");
            }
        }
        public async Task<(bool success, string? message)> DeleteAsync(int id)
        {
            try
            {
                var wasDeleted = await _provider.Delete(id);

                return (wasDeleted, "");
            }
            catch (Exception ex)
            {
                return (false, $"{ex.Message}");
            }
        }

    }
}
