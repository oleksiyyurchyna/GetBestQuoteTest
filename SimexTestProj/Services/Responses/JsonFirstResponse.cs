using Newtonsoft.Json;

namespace SimexTestProj.Services.Responses
{
    public class JsonFirstResponse
    {
        [JsonProperty("total")]
        public double Quote { get; set; }
    }
}
