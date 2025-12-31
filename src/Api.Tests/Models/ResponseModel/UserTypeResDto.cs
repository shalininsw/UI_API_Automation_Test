using Newtonsoft.Json;

namespace Api.Tests.Models.ResponseModels
{
    public class UserTypeResDto
    {
        [JsonProperty("usertype")]
        public string Type { get; set; }
    }
}