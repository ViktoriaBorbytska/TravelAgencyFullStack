using System.Collections.Generic;

namespace TravelAgency.Interfaces.Dto.Models.Account
{
    public class ClientAccountModel
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string Passport { get; set; }

        public string PhotoPath { get; set; }

        public string Role { get; set; }
    }
}