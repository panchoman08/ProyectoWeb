using ProyectoWeb.Models;
using ProyectoWeb.Models.ErrorModel;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace ProyectoWeb.Providers.APiFerreteria.product_state
{
    public class ProductCatProvider
    {

        private readonly RestClient _client;

        public ProductCatProvider()
        {
            _client = new RestClient("https://localhost:7198/api/productCat");
        }

        public async Task<List<ProductCatModel>> All()
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

            var categories = JsonConvert.DeserializeObject<List<ProductCatModel>>(response.Content);
            return categories;
        }

        public async Task<ProductCatModel> GetById(int id)
        {
            var request = new RestRequest($"/{id}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var category = JsonConvert.DeserializeObject<ProductCatModel>(response.Content);
            return category;
        }

        public async Task<ProductCatModel> GetByName(string name)
        {
            var request = new RestRequest($"/{name}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var category = JsonConvert.DeserializeObject<ProductCatModel>(response.Content);
            return category;
        }


        public async Task<bool> Create(ProductCatCreateModel category)
        {
            var request = new RestRequest();
            request.AddJsonBody(category);

            RestResponse response = await _client.ExecutePostAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse(response.Content);
            }

            return true;
        }

        public async Task<bool> Update(ProductCatCreateModel product, int id)
        {
            var request = new RestRequest($"/{id}");
            request.AddJsonBody(product);

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
