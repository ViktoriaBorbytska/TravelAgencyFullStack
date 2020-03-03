using System.Linq;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.Interfaces.Services.Pipeline.Interfaces;

namespace TravelAgency.DatabaseAccess.Pipeline.Filters
{
    internal class OfferDestinationFilter : IFilter<IQueryable<Offer>>
    {
        private readonly string substring;

        public OfferDestinationFilter(string substring)
        {
            this.substring = substring;
        }

        public IQueryable<Offer> Execute(IQueryable<Offer> input) => string.IsNullOrEmpty(substring)
            ? input
            : input.Where(offer => offer.Destination.ToLower().Contains(substring.ToLower()));
    }
}
