using Newtonsoft.Json;
using ProyectoWeb.Models.ErrorModel;
using ProyectoWeb.Models.supplier_category;
using RestSharp;
using System.Net;

namespace ProyectoWeb.Providers.APiFerreteria.supplier_category
{
    public class SupplierCatProvider
    {

        private readonly RestClient _client;

        public SupplierCatProvider()
        {
            _client = new RestClient("https://localhost:7198/api/supplierCat");
        }

        public async Task<List<SupplierCatModel>> All()
        {
            var request = new RestRequest("/all");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorException($"{response.Content}");
            }

            var categories = JsonConvert.DeserializeObject<List<SupplierCatModel>>(response.Content);
            return categories;
        }


        public async Task<SupplierCatModel> GetById(int id)
        {
            var request = new RestRequest($"/{id}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var categories = JsonConvert.DeserializeObject<SupplierCatModel>(response.Content);
            return categories;
        }

        public async Task<SupplierCatModel> GetByName(string name)
        {
            var request = new RestRequest($"/{name}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var categories = JsonConvert.DeserializeObject<SupplierCatModel>(response.Content);
            return categories;
        }


        public async Task<bool> Create(SupplierCatCreateModel category)
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

        public async Task<bool> Update(SupplierCatCreateModel category, int id)
        {
            var request = new RestRequest($"/{id}");
            request.AddJsonBody(category);

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
