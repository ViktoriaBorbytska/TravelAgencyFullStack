using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<SubscriberData> AddAsycn(string subscriberData);

        Task<IReadOnlyCollection<SubscriberData>> GetAsync();
    }
}
