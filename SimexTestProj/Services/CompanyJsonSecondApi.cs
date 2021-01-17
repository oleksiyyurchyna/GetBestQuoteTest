using AutoMapper;
using Newtonsoft.Json;
using SimexTestProj.Services.Requests;
using SimexTestProj.Services.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace SimexTestProj.Services
{
    public class CompanyJsonSecondApi : BaseCompanyApi<JsonSecondRequest, JsonSecondResponse>
    {
        public CompanyJsonSecondApi(IMapper mapper)
            : base(mapper)
        {
        }

        protected override Task<JsonSecondResponse> ProcessRequest(JsonSecondRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            // processing json...

            var result = JsonConvert.DeserializeObject<JsonSecondResponse>("{ \"amount\": 50 }");

            return Task.FromResult(result);
        }
    }
}
