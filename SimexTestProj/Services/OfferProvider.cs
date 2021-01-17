using SimexTestProj.Enums;
using SimexTestProj.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimexTestProj.Services
{
    public class OfferProvider
    {
        private readonly CompanyApiResolver _apiResolver;

        public OfferProvider(CompanyApiResolver apiResolver)
        {
            _apiResolver = apiResolver;
        }

        public async Task<Offer> FindBestOffer(OfferParameters parameters)
        {
            var allCompanies = GetAllCompanies();

            var tasks = new List<Task<Offer>>();
            foreach (var company in allCompanies)
            {
                // get api depending on company type
                var api = _apiResolver(company.Type);

                // get task for receiving an offer
                var getOfferTask = api.GetOffer(parameters);
                tasks.Add(getOfferTask);
            }

            // once all offers loaded
            await Task.WhenAll(tasks);

            var offers = tasks.Select(x => x.Result).ToList();
            return offers.OrderBy(x => x.Quote).FirstOrDefault();
        }

        private static List<Company> GetAllCompanies()
        {
            return new List<Company>()
            {
                new Company(){ Type = CompanyType.ApiJsonFirst},
                new Company(){ Type = CompanyType.ApiJsonSecond},
                new Company(){ Type = CompanyType.ApiXml},
            };
        }
    }
}
