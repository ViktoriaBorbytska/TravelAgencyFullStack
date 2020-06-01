using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface IApplicationRoleRepository
    {
        RoleData Get(string name);

        RoleData Get(int id);
    }
}