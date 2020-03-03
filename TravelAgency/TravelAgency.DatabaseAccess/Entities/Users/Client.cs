using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.DatabaseAccess.Entities.Users
{
    internal class Client
    {
        public int Id { get; set; }

        public string FirstName { get; set; }    
        
        public string LastName { get; set; }    
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        public string Phone { get; set; }
    }
}
