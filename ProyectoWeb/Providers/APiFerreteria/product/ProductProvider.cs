using Newtonsoft.Json;
using ProyectoWeb.Models;
using ProyectoWeb.Models.ErrorModel;
using RestSharp;
using System.Net;

namespace ProyectoWeb.Providers.APiFerreteria.product
{
    public class ProductProvider
    {
        private readonly RestClient _client;
        public ProductProvider()
        {
            _client = new RestClient("https://localhost:7198/api/product");
        }

        public async Task<List<ProductModel>> AllProducts()
        {
            /*var options = new RestClientOptions("https://localhost:7198/api/product")
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

            var products = JsonConvert.DeserializeObject<List<ProductModel>>(response.Content);
            return products;
        } 

        public async Task<ProductModel> GetProductById(int id)
        {
            var request = new RestRequest($"/{id}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var product = JsonConvert.DeserializeObject<ProductModel>(response.Content);
            return product;
        }

        public async Task<ProductModel> GetProductByName(string name)
        {
            var request = new RestRequest($"/{name}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var product = JsonConvert.DeserializeObject<ProductModel>(response.Content);
            return product;
        }

        public async Task<ProductModel> GetProductBySku(string sku)
        {
            var request = new RestRequest($"/sku/{sku}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var product = JsonConvert.DeserializeObject<ProductModel>(response.Content);
            return product;
        }

        public async Task<bool> Create(ProductCreate productCreate)
        {
            var request = new RestRequest();
            request.AddJsonBody(productCreate);

            RestResponse response = await _client.ExecutePostAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse(response.Content);
            }

            return true;
        }

        public async Task<bool> Update(ProductCreate product, int id)
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
