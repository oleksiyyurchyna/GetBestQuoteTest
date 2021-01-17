using AutoMapper;
using SimexTestProj.Models;
using SimexTestProj.Services.Requests;
using SimexTestProj.Services.Responses;

namespace SimexTestProj
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OfferParameters, JsonFirstRequest>();
            CreateMap<OfferParameters, JsonSecondRequest>();
            CreateMap<OfferParameters, XmlApiRequest>();

            CreateMap<JsonFirstResponse, Offer>();
            CreateMap<JsonSecondResponse, Offer>();
            CreateMap<XmlApiResponse, Offer>();
        }
    }
}
