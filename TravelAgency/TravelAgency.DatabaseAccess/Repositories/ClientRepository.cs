using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DatabaseAccess.Entities.Users;
using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.DatabaseAccess.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly ITravelAgencyDbContext context;
        private readonly IApplicationUserRepository applicationUserRepository;

        public ClientRepository(ITravelAgencyDbContext context, IApplicationUserRepository applicationUserRepository)
        {
            this.context = context;
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task<ClientData> AddAsync(ClientData clientData)
        {
            var creatingResult = await context.Clients.AddAsync(Map(clientData));

            await context.SaveChangesAsync();

            return Map(creatingResult.Entity);
        }

        public async Task<ClientData> FindByIdAsync(int id)
            => Map(await context.Clients.FindAsync(id));

        public ClientData FindByUser(UserData userData)
        {
            var user = context.Clients.FirstOrDefault((client) => client.UserId == userData.Id);

            return Map(user);
        }

        public async Task<bool> UpdateAsync(ClientData clientData)
        {
            Client client = await context.Clients.FindAsync(clientData.Id);

            context.Clients.Update(client);
            await context.SaveChangesAsync();
            return true;
        }

        private ClientData Map(Client client)
            => new ClientData
            {
                Name = client.FirstName,
                Surname = client.LastName,
                UserId = client.UserId
            };

        private Client Map(ClientData clientData)
            => new Client
            {
                FirstName = clientData.Name,
                LastName = clientData.Surname,
                UserId = clientData.UserId,
                Phone = clientData.Phone
            };
    }
}
