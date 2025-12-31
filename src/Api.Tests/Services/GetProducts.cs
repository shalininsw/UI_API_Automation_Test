using RestSharp;
using Api.Tests.Base;

namespace Api.Tests.Services
{
    public class GetProducts: BaseService
    {
        private readonly BaseService _service;
        public GetProducts(RestClient client) : base(client){}
       
        public async Task<RestResponse> GetProductList()
        {
            return await GetAsync("api/productsList");
        }
    }
}