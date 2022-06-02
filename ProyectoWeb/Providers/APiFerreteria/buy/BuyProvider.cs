using Newtonsoft.Json;
using ProyectoWeb.Models.buy;
using ProyectoWeb.Models.ErrorModel;
using RestSharp;
using System.Net;

namespace ProyectoWeb.Providers.APiFerreteria.buy
{
    public class BuyProvider
    {
        private readonly RestClient _client;
        public BuyProvider()
        {
            this._client = new RestClient("https://localhost:7198/api/buy");
        }

        public async Task<List<BuyModel>> All()
        {

            var request = new RestRequest("/all");
            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var buys = JsonConvert.DeserializeObject<List<BuyModel>>(response.Content);
            return buys;
        }

        public async Task<BuyModel> GetById(int id)
        {
            var request = new RestRequest($"/{id}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var buy = JsonConvert.DeserializeObject<BuyModel>(response.Content);
            return buy;
        }

        public async Task<bool> Create(BuyCreateModel buy)
        {
            var request = new RestRequest();
            request.AddJsonBody(buy);

            RestResponse response = await _client.ExecutePostAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse(response.Content);
            }

            return true;
        }

        public async Task<bool> Update(BuyCreateModel buy, int id)
        {
            var request = new RestRequest($"/{id}");
            request.AddJsonBody(buy);

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
