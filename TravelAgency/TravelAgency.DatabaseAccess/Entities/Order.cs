using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.DatabaseAccess.Entities
{
    internal class Order
    {
        public int Id { get; set; }

        [ForeignKey("Offer")]
        public int OfferId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        
        public bool IsBooked { get; set; }
        
        public int ChildrenCount { get; set; }
        
        public int AdultCount { get; set; }
        
        public int Price { get; set; }
        
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }
    }
}
