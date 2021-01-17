using Newtonsoft.Json;

namespace SimexTestProj.Services.Requests
{
    public class JsonFirstRequest
    {
        [JsonProperty("contact address")]
        public string SourceAddress { get; set; }
        [JsonProperty("warehouse address")]
        public string DestinationAddress { get; set; }
        [JsonProperty("package dimensions")]
        public string[] CartonDimensions { get; set; }
    }
}
