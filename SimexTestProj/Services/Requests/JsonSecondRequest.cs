using Newtonsoft.Json;

namespace SimexTestProj.Services.Requests
{
    public class JsonSecondRequest
    {
        [JsonProperty("consignee")]
        public string SourceAddress { get; set; }
        [JsonProperty("consignor")]
        public string DestinationAddress { get; set; }
        [JsonProperty("cartons")]
        public string[] CartonDimensions { get; set; }
    }
}
