using AutoMapper;
using Newtonsoft.Json;
using SimexTestProj.Services.Requests;
using SimexTestProj.Services.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace SimexTestProj.Services
{
    public class CompanyJsonFirstApi : BaseCompanyApi<JsonFirstRequest, JsonFirstResponse>
    {
        public CompanyJsonFirstApi(IMapper mapper)
            : base(mapper)
        {
        }

        protected override Task<JsonFirstResponse> ProcessRequest(JsonFirstRequest request)
        {
            var json = JsonConvert.SerializeObject(request);

            // processing json...

            var result = JsonConvert.DeserializeObject<JsonFirstResponse>("{ \"total\": 25 }");

            return Task.FromResult(result);
        }
    }
}
