using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Tests.Models.ResponseModel;

namespace Api.Tests.Utilities
{
    public static class AssertHelpers
    {
        public static void AssertResponse(CreateAccountResDto responseObj, int expectedCode, string expectedMessage)
        {
            Assert.AreEqual(expectedCode, responseObj.responseCode);
            Assert.AreEqual(expectedMessage, responseObj.message);
        }

        public static void AssertStatusCode(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
