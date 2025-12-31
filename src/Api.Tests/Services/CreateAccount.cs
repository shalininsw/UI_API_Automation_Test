using RestSharp;
using Api.Tests.Base;

namespace Api.Tests.Services
{
    public class CreateAccount : BaseService
    {
        private readonly BaseService _service;
        public CreateAccount(RestClient client) : base(client) { }

        public async Task<RestResponse> RegisterUser(Dictionary<string, string> formData)
        {
            return await PostFormUrlEncodedAsync("api/createAccount", formData);
        }
    }
}