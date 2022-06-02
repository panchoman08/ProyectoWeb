using Newtonsoft.Json;
using ProyectoWeb.Models.customer_category;
using ProyectoWeb.Models.ErrorModel;
using RestSharp;
using System.Net;

namespace ProyectoWeb.Providers.APiFerreteria.customer_category
{
    public class CustomerCatProvider
    {

        private readonly RestClient _client;
        public CustomerCatProvider()
        {
            this._client = new RestClient("https://localhost:7198/api/customerCat");
        }

        public async Task<List<CustomerCatModel>> All()
        {

            var request = new RestRequest("/all");
            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var categories = JsonConvert.DeserializeObject<List<CustomerCatModel>>(response.Content);
            return categories;
        }

        public async Task<CustomerCatModel> GetById(int id)
        {
            var request = new RestRequest($"/{id}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var category = JsonConvert.DeserializeObject<CustomerCatModel>(response.Content);
            return category;
        }

        public async Task<CustomerCatModel> GetByName(string name)
        {
            var request = new RestRequest($"/{name}");

            RestResponse response = await _client.ExecuteGetAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ErrorResponse($"{response.Content}");
            }

            var category = JsonConvert.DeserializeObject<CustomerCatModel>(response.Content);
            return category;
        }


        public async Task<bool> Create(CustomerCatCreateModel category)
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

        public async Task<bool> Update(CustomerCatCreateModel category, int id)
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
