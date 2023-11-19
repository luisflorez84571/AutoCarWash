using Newtonsoft.Json;

namespace CarWashing.Shared.Responses
{
    public class VehicleResponse
    {
        [JsonProperty("id")]
        public long VehicleId { get; set; }

        [JsonProperty("name")]
        public string NumeroPlaca { get; set; }
    }
}
