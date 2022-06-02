using Newtonsoft.Json;
using ProyectoWeb.Models.ErrorModel;
using ProyectoWeb.Models.product_measure;
using RestSharp;
using System.Net;

namespace ProyectoWeb.Providers.APiFerreteria.product_measure
{
    public class ProductMeasureProvider
    {

        private readonly RestClient _client;

        public ProductMeasureProvider()
        {
            _client = new RestClient("https://localhost:7198/api/productMeasure");
        }

        public async Task<List<ProductMeasureModel>> All()
        {
            /*var options = new RestClientOptions("https://localhost:7198/api/productCat")
            {
                Timeout = 20000,
                ThrowOnAnyError = true
            };*/

            var request = new RestRequest("/all");
            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var measures = JsonConvert.DeserializeObject<List<ProductMeasureModel>>(response.Content);
            return measures;
        }

        public async Task<ProductMeasureModel> GetById(int id)
        {
            var request = new RestRequest($"/{id}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var measure = JsonConvert.DeserializeObject<ProductMeasureModel>(response.Content);
            return measure;
        }

        public async Task<ProductMeasureModel> GetByName(string name)
        {
            var request = new RestRequest($"/{name}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var measure = JsonConvert.DeserializeObject<ProductMeasureModel>(response.Content);
            return measure;
        }


        public async Task<bool> Create(ProductMeasureCreateModel measure)
        {
            var request = new RestRequest();
            request.AddJsonBody(measure);

            RestResponse response = await _client.ExecutePostAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse(response.Content);
            }

            return true;
        }

        public async Task<bool> Update(ProductMeasureCreateModel measure, int id)
        {
            var request = new RestRequest($"/{id}");
            request.AddJsonBody(measure);

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
