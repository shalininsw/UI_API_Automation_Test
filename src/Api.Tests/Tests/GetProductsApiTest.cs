using Api.Tests.Base;
using Api.Tests.Services;
using Api.Tests.Utilities;
using Newtonsoft.Json;
using Api.Tests.Models.ResponseModels;

namespace Api.Tests.Tests

{
    [TestClass]
    public class GetProductApiTests : BaseApiTest
    {
        private GetProducts _getProducts;

        [TestInitialize]
        public void SetupService()
        {
            // Each test gets its own service instance
            _getProducts = new GetProducts(client); }

        [TestMethod]
        [TestCategory("api")]
        public async Task GetProducts_ShouldReturn200()
        {
            var response = await _getProducts.GetProductList();
            ProductResponseDto responseObj = JsonConvert.DeserializeObject<ProductResponseDto>(response.Content);
            AssertHelpers.AssertStatusCode(responseObj.ResponseCode, 200);
        }
        
        [TestMethod]
        [TestCategory("api")]
        public async Task GetProducts_SchemaValidation()
        {
            var response = await _getProducts.GetProductList();
            var fullPath = RequestHelper.GetFullPath("src/Api.Tests/Data/ApiSchema/GetProductsApiSchema.json");
            Assert.IsTrue(JsonSchemaValidator.IsSchemaValid(response.Content, fullPath));
        }

    }
}