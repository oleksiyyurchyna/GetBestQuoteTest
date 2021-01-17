using AutoMapper;
using SimexTestProj.Models;
using System.Threading.Tasks;

namespace SimexTestProj.Services
{
    public abstract class BaseCompanyApi<T, TRes> : ICompanyApi
    {
        private IMapper _mapper;

        protected abstract Task<TRes> ProcessRequest(T request);

        public BaseCompanyApi(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Offer> GetOffer(OfferParameters parameters)
        {
            var request = _mapper.Map<T>(parameters);
            var result = await ProcessRequest(request);
            return _mapper.Map<Offer>(result);
        }
    }
}
