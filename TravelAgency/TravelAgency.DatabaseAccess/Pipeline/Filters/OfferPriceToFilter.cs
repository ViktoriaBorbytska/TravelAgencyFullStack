using System.Linq;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.Interfaces.Services.Pipeline.Interfaces;

namespace TravelAgency.DatabaseAccess.Pipeline.Filters
{
    internal class OfferPriceToFilter : IFilter<IQueryable<Offer>>
    {
        private readonly int? priceTo;

        public OfferPriceToFilter(int? priceTo)
        {
            this.priceTo = priceTo;
        }

        public IQueryable<Offer> Execute(IQueryable<Offer> input) => priceTo == null
        ? input
        : input.Where(offer => offer.Price <= priceTo);
    }
}
