using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TravelAgency.DatabaseAccess.Entities.Identity
{
    internal class User : IdentityUser<int>
    {
        [ForeignKey("IdentityRole<int>")]
        public int RoleId { get; set; }
    }
}
