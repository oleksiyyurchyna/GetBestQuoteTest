using Newtonsoft.Json;

namespace SimexTestProj.Services.Responses
{
    public class JsonSecondResponse
    {
        [JsonProperty("amount")]
        public double Quote { get; set; }
    }
}
