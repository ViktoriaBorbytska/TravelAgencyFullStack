using System.Collections.Generic;
using System.Linq;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.DatabaseAccess.Repositories
{
    internal class ApplicationRoleRepository : IApplicationRoleRepository
    {
        private readonly IReadOnlyCollection<RoleData> roles;

        public ApplicationRoleRepository()
        {
            var authorizedUserRole = new RoleData
            {
                Name = "client",
                Id = 1
            };
            var managerRole = new RoleData
            {
                Name = "manager",
                Id = 2
            };
            this.roles = new List<RoleData> { authorizedUserRole, managerRole };
        }

        public RoleData Get(string name)
            => roles.ToList().FirstOrDefault((role) => role.Name == name.ToLower());

        public RoleData Get(int id) => roles.ElementAt(id - 1);
    }
}