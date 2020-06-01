using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.DatabaseAccess.Repositories
{
    internal class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ITravelAgencyDbContext context;

        public SubscriptionRepository(ITravelAgencyDbContext context)
        {
            this.context = context;
        }

        public async Task<SubscriberData> AddAsycn(string subscriberEmail)
        {
            var insertionResult = await context.Subscribers.AddAsync(Map(subscriberEmail));
            context.SaveChanges();
            return Map(insertionResult.Entity);
        }

        public async Task<IReadOnlyCollection<SubscriberData>> GetAsync()
        {
            return Map(await context.Subscribers.ToListAsync());
        }

        private IReadOnlyCollection<SubscriberData> Map(IReadOnlyCollection<Subscriber> subscribers)
            => subscribers.Select(Map).ToList();

        private Subscriber Map(string subscriberEmail)
             => new Subscriber
             {
                 Email = subscriberEmail
             };

        private SubscriberData Map(Subscriber subscriber)
             => new SubscriberData
             {
                 Id = subscriber.Id,
                 Email = subscriber.Email
             };
    }
}
