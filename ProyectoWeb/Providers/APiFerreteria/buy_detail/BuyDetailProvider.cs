using Newtonsoft.Json;
using ProyectoWeb.Models.buy_detail;
using ProyectoWeb.Models.ErrorModel;
using RestSharp;
using System.Net;

namespace ProyectoWeb.Providers.APiFerreteria.buy_detail
{
    public class BuyDetailProvider
    {

        private readonly RestClient _client;

        public BuyDetailProvider()
        {
            this._client = new RestClient("https://localhost:7198/api/buyDetail");
        }


        public async Task<List<BuyDetailModel>> GetById(int id)
        {
            var request = new RestRequest($"/{id}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var buyDetails = JsonConvert.DeserializeObject<List<BuyDetailModel>>(response.Content);
            return buyDetails;
        }

        public async Task<bool> Create(BuyDetailCreateModel buyDetail)
        {
            var request = new RestRequest();
            request.AddJsonBody(buyDetail);

            RestResponse response = await _client.ExecutePostAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse(response.Content);
            }

            return true;
        }

        public async Task<bool> Update(BuyDetailCreateModel buyDetail, int id)
        {
            var request = new RestRequest($"/{id}");
            request.AddJsonBody(buyDetail);

            RestResponse response = await _client.ExecutePutAsync(request);


            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse(response.Content);
            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var request = new RestRequest($"/{id}");

            RestResponse response = await _client.DeleteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            return true;
        }
    }
}
