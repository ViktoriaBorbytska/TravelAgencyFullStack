using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface ISessionRepository
    {
        Task CreateAsync(SessionData sessionData);

        Task RemoveAsync(SessionData sessionData);

        Task<SessionData> GetByTokenAsync(string token);
    }
}