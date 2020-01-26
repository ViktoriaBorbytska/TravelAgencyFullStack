using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TravelAgency.DatabaseAccess.Entities
{
    class Order
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
