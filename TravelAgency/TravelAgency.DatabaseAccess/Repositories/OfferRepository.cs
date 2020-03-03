using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.DatabaseAccess.Pipeline;
using TravelAgency.DatabaseAccess.Pipeline.Filters;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.DatabaseAccess.Repositories
{
    internal class OfferRepository : IOfferRepository
    {
        private readonly ITravelAgencyDbContext context;

        public OfferRepository(ITravelAgencyDbContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyCollection<OfferData>> GetAsync()
        {
            return Map(await context.Offers.ToListAsync());
        }

        public async Task<IReadOnlyCollection<OfferData>> GetTopAsync()
        {
            return Map(await context.Offers.Where(offer => offer.Mark > 2).ToListAsync());
        }

        public async Task<OfferData> GetAsync(int id)
        {
            Offer offer = await context.Offers.FindAsync(id);
            return offer == null ? null : Map(offer);
        }

        public async Task<IReadOnlyCollection<OfferData>> GetByPageAsync(int page, int pageSize) => Map(
            await context.Offers
                    .OrderBy(offer => offer.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync());

        public async Task<IReadOnlyCollection<OfferData>> GetSearchResultByPageAsync(SearchData searchData, int pageSize)
            => Map(
                await GetSearchResult(searchData)
                    .Skip((searchData.Page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync());

        public async Task<int> CountSearchResultsAsync(SearchData searchData) => await GetSearchResult(searchData).CountAsync();

        private IQueryable<Offer> GetSearchResult(SearchData searchData)
        {
            OfferSelectionPipeline offerSelectionPipeline = new OfferSelectionPipeline();
            offerSelectionPipeline
                .Register(new OfferDestinationFilter(searchData.OfferDestination))
                .Register(new OfferPriceFromFilter(searchData.PriceFrom))
                .Register(new OfferPriceToFilter(searchData.PriceTo));

            return offerSelectionPipeline.Process(context.Offers);
        }

        private IReadOnlyCollection<OfferData> Map(IReadOnlyCollection<Offer> offer)
           => offer.Select(Map).ToList();

        private Offer Map(OfferData offerData)
             => new Offer
             {
                 Id = offerData.Id,
                 Mark = offerData.Mark,
                 Description = offerData.Description,
                 Destination = offerData.Destination,
                 ImageLink = offerData.ImageLink,
                 Price = offerData.Price,
                 DetailedDescription = offerData.DetailedDescription,
                 HotelLink = offerData.HotelLink,
                 HotelName = offerData.HotelName,
                 Inclusions = offerData.Inclusions
             };

        private OfferData Map(Offer offer)
             => new OfferData
             {
                 Id = offer.Id,
                 Mark = offer.Mark,
                 Description = offer.Description,
                 Destination = offer.Destination,
                 ImageLink = offer.ImageLink,
                 Price = offer.Price,
                 DetailedDescription = offer.DetailedDescription,
                 HotelLink = offer.HotelLink,
                 HotelName = offer.HotelName,
                 Inclusions = offer.Inclusions
             };
    }
}
