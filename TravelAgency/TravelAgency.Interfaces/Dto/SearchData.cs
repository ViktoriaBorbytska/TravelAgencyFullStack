namespace TravelAgency.Interfaces.Dto
{
    public class SearchData
    {
        public string OfferDestination { get; set; }

        public int? PriceFrom { get; set; }

        public int? PriceTo { get; set; }

        public int Page { get; set; }
    }
}
