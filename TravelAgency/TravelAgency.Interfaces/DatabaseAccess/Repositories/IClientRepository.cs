using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface IClientRepository
    {
        Task<ClientData> AddAsync(ClientData clientData);

        Task<ClientData> FindByIdAsync(int id);

        ClientData FindByUser(UserData userData);
    }
}
