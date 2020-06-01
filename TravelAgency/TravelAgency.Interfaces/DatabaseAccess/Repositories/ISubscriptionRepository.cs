using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Dto.Models;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<DefaultResponseModel> AddAsycn(string subscriberData);

        Task<IReadOnlyCollection<SubscriberData>> GetAsync();
    }
}
