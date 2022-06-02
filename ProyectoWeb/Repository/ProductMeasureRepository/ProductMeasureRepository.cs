using ProyectoWeb.Models.product_measure;
using ProyectoWeb.Providers.APiFerreteria.product_measure;

namespace ProyectoWeb.Repository.ProductMeasureRepository
{
    public class ProductMeasureRepository : IProductMeasureRepository
    {
        private readonly ProductMeasureProvider _provider;

        public ProductMeasureRepository(ProductMeasureProvider providerMeassure)
        {
            this._provider = providerMeassure;
        }

        public async Task<List<ProductMeasureModel>> GetAllAsync()
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

        public Task<List<ProductMeasureModel>> GetAllThatContainsAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, ProductMeasureModel measure)> GetByIdAsync(int id)
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

        public async Task<(bool success, ProductMeasureModel measure)> GetByNameAsync(string name)
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
        public async Task<(bool success, string? message)> CreateAsync(ProductMeasureCreateModel measure)
        {
            try
            {
                bool success = await _provider.Create(measure);

                return (success, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<(bool success, string? message)> UpdateAsync(ProductMeasureCreateModel measure, int id)
        {
            try
            {
                bool success = await _provider.Update(measure, id);

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
