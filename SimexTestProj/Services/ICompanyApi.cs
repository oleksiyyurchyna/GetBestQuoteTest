using SimexTestProj.Models;
using System.Threading.Tasks;

namespace SimexTestProj.Services
{
    public interface ICompanyApi
    {
        public Task<Offer> GetOffer(OfferParameters parameters);
    }
}
