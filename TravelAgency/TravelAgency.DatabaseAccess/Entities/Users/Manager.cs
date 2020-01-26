using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TravelAgency.DatabaseAccess.Entities.Users
{
    internal class Manager
    {
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
    }
}
