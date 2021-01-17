using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SimexTestProj.Enums;
using SimexTestProj.Models;
using SimexTestProj.Services;
using System;
using System.Collections.Generic;

namespace SimexTestProj
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            ConfigureDi();

            var offerRequestParameters = new OfferParameters()
            {
                SourceAddress = "Toronto",
                DestinationAddress = "Ottawa",
                CartonDimensions = new string[]
                {
                    "L30",
                    "H45",
                    "W60"
                }
            };

            var offerProvider = _serviceProvider.GetService<OfferProvider>();
            var bestOffer = offerProvider.FindBestOffer(offerRequestParameters).Result;

            Console.WriteLine($"Best offer has total of '{bestOffer.Quote}'");
            Console.ReadKey();
        }

        private static void ConfigureDi()
        {
            var services = new ServiceCollection();
            
            services.AddTransient<CompanyJsonFirstApi>();
            services.AddTransient<CompanyJsonSecondApi>();
            services.AddTransient<CompanyXmlApi>();
            services.AddTransient<CompanyApiResolver>(x => companyType =>
            {
                switch (companyType)
                {
                    case CompanyType.ApiJsonFirst:
                        return x.GetService<CompanyJsonFirstApi>();
                    case CompanyType.ApiJsonSecond:
                        return x.GetService<CompanyJsonSecondApi>();
                    case CompanyType.ApiXml:
                        return x.GetService<CompanyXmlApi>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            services.AddSingleton<OfferProvider>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
