using Microsoft.AspNetCore.Identity;

namespace TravelAgency.DatabaseAccess.Entities.Identity
{
    internal class Role : IdentityRole<int>
    {        
        public Role(string name)
            : base(name)
        {

        }
    }
}
