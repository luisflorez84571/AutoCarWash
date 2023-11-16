using Newtonsoft.Json;

namespace CarWashing.Shared.Responses
{
    public class ClientResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
