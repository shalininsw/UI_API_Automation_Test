using Api.Tests.Base;
using Api.Tests.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Api.Tests.Models.ResponseModel;
using Api.Tests.Utilities;

namespace Api.Tests.Tests

{
    [TestClass]
    public class CreateAccountApiTest : BaseApiTest
    {
        private CreateAccount _createAccount;

        [TestInitialize]
        public void SetupService()
        {
            // Each test gets its own service instance
            _createAccount = new CreateAccount(client);
        }

        [TestMethod]
        [TestCategory("api")]
        public async Task CreateProduct_ShouldReturn201()
        {

            //Arrange
            var product = RequestHelper.LoadDtoFromJson<CreateAccountReqDto>("src/Api.Tests/Data/ApiRequests/CreateAccountReq.json");

            product.name = "Product_" + Guid.NewGuid().ToString("N");
            product.email = "User_" + Guid.NewGuid().ToString("N") + "@example.com";
            var dict = RequestHelper.ToFormDictionary(product);

            //Act

            var response = await _createAccount.RegisterUser(dict);
            var responseObj = JsonConvert.DeserializeObject<CreateAccountResDto>(response.Content);

            //Assert
            AssertHelpers.AssertResponse(responseObj, 201, "User created!");

        }

    }
}