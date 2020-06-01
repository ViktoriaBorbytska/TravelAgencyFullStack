using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.DatabaseAccess.Entities
{
    internal class Order
    {
        public int Id { get; set; }

        [ForeignKey("Offer")]
        public int OfferId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
    }
}
