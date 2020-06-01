using System;

namespace TravelAgency.Interfaces.Dto.Models.Booking
{
    public class AddOrderModel
    {
        public string Token { get; set; }

        public int OfferId { get; set; }

        public int ChildrenCount { get; set; }
        
        public int AdultCount { get; set; }
        
        public int Price { get; set; }
        
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }
    }
}