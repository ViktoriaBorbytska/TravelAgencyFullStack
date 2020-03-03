using System.Linq;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.Interfaces.Services.Pipeline.Interfaces;

namespace TravelAgency.DatabaseAccess.Pipeline.Filters
{
    internal class OfferPriceFromFilter : IFilter<IQueryable<Offer>>
    {
        private readonly int? priceFrom;

        public OfferPriceFromFilter(int? priceFrom)
        {
            this.priceFrom = priceFrom;
        }

        public IQueryable<Offer> Execute(IQueryable<Offer> input) => priceFrom == null
            ? input
            : input.Where(offer => offer.Price >= priceFrom);
    }
}
