using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Services.Interfaces.Handlers
{
    internal interface ISessionHandler
    {
       Task<ClientData> GetUserAsync(string token);
    }
}