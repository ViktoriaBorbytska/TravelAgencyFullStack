using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto.Models;

namespace TravelAgency.Interfaces.Services
{
    public interface ISubscriptionService
    {
        Task<DefaultResponseModel> AddAsync(string subscriberEmail);

        Task SendEmailAsync();
    }
}
