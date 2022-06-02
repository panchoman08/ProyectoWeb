using ProyectoWeb.Models.buy_detail;
using ProyectoWeb.Providers.APiFerreteria.buy_detail;

namespace ProyectoWeb.Repository.BuyDetailRepositories
{
    public class BuyDetailRepository
    {
        private readonly BuyDetailProvider _provider;

        public BuyDetailRepository() 
        {
            this._provider = new BuyDetailProvider();
        }

        public async Task<(bool success, List<BuyDetailModel> buyDetail)> GetByIdAsync(int id)
        {
            try
            {
                var buyDetails = await _provider.GetById(id);

                return (true, buyDetails);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }

        public async Task<(bool success, string? message)> CreateAsync(BuyDetailCreateModel buyDetail)
        {
            try
            {
                bool success = await _provider.Create(buyDetail);

                return (success, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<(bool success, string? message)> UpdateAsync(int id, BuyDetailCreateModel buyDetail)
        {
            try
            {
                bool success = await _provider.Update(buyDetail, id);

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
