using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.DatabaseAccess.Entities
{
    internal class Session
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Token { get; set; }
    }
}
