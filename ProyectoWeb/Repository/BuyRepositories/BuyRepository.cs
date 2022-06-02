using ProyectoWeb.Models.buy;
using ProyectoWeb.Providers.APiFerreteria.buy;

namespace ProyectoWeb.Repository.BuyRepositories
{
    public class BuyRepository
    {
        private readonly BuyProvider _provider;
        public BuyRepository()
        {
            _provider = new BuyProvider();
        }

        public async Task<List<BuyModel>> GetAllAsync()
        {
            try
            {
                var buys = await _provider.All();

                return buys;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<BuyModel>> GetAllThatContainsAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool success, BuyModel buy)> GetByIdAsync(int id)
        {
            try
            {
                var buy = await _provider.GetById(id);

                return (true, buy);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }

        public async Task<(bool success, BuyModel buy)> GetByNameAsync(string name)
        {
            try
            {
                //var customer = await _provider.GetByName(name);

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }
        public async Task<(bool success, string? message)> CreateAsync(BuyCreateModel buy)
        {
            try
            {
                bool success = await _provider.Create(buy);

                return (success, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<(bool success, string? message)> UpdateAsync(int id, BuyCreateModel buy)
        {
            try
            {
                bool success = await _provider.Update(buy, id);

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
