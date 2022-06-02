using Newtonsoft.Json;
using ProyectoWeb.Models.customer;
using ProyectoWeb.Models.ErrorModel;
using RestSharp;
using System.Net;

namespace ProyectoWeb.Providers.APiFerreteria.customer
{
    public class CustomerProvider
    {
        private readonly RestClient _client;
        public CustomerProvider()
        {
            _client = new RestClient("https://localhost:7198/api/customer");
        }

        public async Task<List<CustomerModel>> All()
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

            var customers = JsonConvert.DeserializeObject<List<CustomerModel>>(response.Content);
            return customers;
        }

        public async Task<CustomerModel> GetById(int id)
        {
            var request = new RestRequest($"/{id}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var customer = JsonConvert.DeserializeObject<CustomerModel>(response.Content);
            return customer;
        }

        public async Task<CustomerModel> GetByName(string name)
        {
            var request = new RestRequest($"/{name}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var customer = JsonConvert.DeserializeObject<CustomerModel>(response.Content);
            return customer;
        }


        public async Task<bool> Create(CustomerCreateModel category)
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

        public async Task<bool> Update(CustomerCreateModel customer, int id)
        {
            var request = new RestRequest($"/{id}");
            request.AddJsonBody(customer);

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
