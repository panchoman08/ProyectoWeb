using RestSharp;

namespace ProyectoWeb.Utils
{
    public class APiHelper
    {
        private readonly RestClient _client;

        public APiHelper()
        {
            this._client = new RestClient();
        }

        public APiHelper(string url)
        {
            this._client = new RestClient(url);
        }

        public async Task<RestResponse> GetRequest(string uri)
        {
            var request = new RestRequest(uri);
            
            RestResponse response = await _client.ExecuteGetAsync(request);

            return response;
        }

        public async Task<RestResponse> PostRequest(string url, Object body)
        {
            var request = new RestRequest();
            request.AddJsonBody(body);

            RestResponse response = await _client.ExecutePostAsync(request);

            return response;
        }

        public async Task<RestResponse> DeleteRequest(string url)
        {
            var request = new RestRequest(url);

            RestResponse response = await _client.DeleteAsync(request);

            return response;
        }

    }
}
