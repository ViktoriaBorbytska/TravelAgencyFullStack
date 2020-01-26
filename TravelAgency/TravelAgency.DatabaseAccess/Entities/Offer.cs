using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgency.DatabaseAccess.Entities
{
    internal class Offer
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public decimal Price { get; set; }

        public string Destination { get; set; }

        public string ImageLink { get; set; }

        public string Description { get; set; }

        public string HotelName { get; set; }

        public string HotelLink { get; set; }

        public string DetailedDescription { get; set; }

        public string Inclusions { get; set; }
    }
}
