using Newtonsoft.Json;
using ProyectoWeb.Models.ErrorModel;
using ProyectoWeb.Models.supplier;
using RestSharp;
using System.Net;

namespace ProyectoWeb.Providers.APiFerreteria.supplier
{
    public class SupplierProvider
    {

        private readonly RestClient _client;
        public SupplierProvider()
        {
            _client = new RestClient("https://localhost:7198/api/supplier");
        }


        public async Task<List<SupplierModel>> All()
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

            var measures = JsonConvert.DeserializeObject<List<SupplierModel>>(response.Content);
            return measures;
        }

        public async Task<SupplierModel> GetById(int id)
        {
            var request = new RestRequest($"/{id}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var measure = JsonConvert.DeserializeObject<SupplierModel>(response.Content);
            return measure;
        }

        public async Task<SupplierModel> GetByName(string name)
        {
            var request = new RestRequest($"/{name}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var measure = JsonConvert.DeserializeObject<SupplierModel>(response.Content);
            return measure;
        }


        public async Task<bool> Create(SupplierCreateModel supplier)
        {
            var request = new RestRequest();
            request.AddJsonBody(supplier);

            RestResponse response = await _client.ExecutePostAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse(response.Content);
            }

            return true;
        }

        public async Task<bool> Update(SupplierCreateModel supplier, int id)
        {
            var request = new RestRequest($"/{id}");
            request.AddJsonBody(supplier);

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
