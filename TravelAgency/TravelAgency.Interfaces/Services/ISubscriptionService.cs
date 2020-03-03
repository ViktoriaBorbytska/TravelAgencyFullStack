using System.Threading.Tasks;

namespace TravelAgency.Interfaces.Services
{
    public interface ISubscriptionService
    {
        Task AddAsync(string subscriberEmail);

        Task SendEmailAsync();
    }
}
