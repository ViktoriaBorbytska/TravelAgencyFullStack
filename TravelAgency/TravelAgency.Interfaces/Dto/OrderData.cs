using System;

namespace TravelAgency.Interfaces.Dto
{
    public class OrderData
    {
        public int Id { get; set; }
        
        public int OfferId { get; set; }
        
        public int ClientId { get; set; }
        
        public int ManagerId { get; set; }
        
        public bool IsBooked { get; set; }
        
        public int ChildrenCount { get; set; }
        
        public int AdultCount { get; set; }
        
        public int Price { get; set; }
        
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }
    }
}