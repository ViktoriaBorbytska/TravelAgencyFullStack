using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Dto.Models;

namespace TravelAgency.DatabaseAccess.Repositories
{
    internal class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ITravelAgencyDbContext context;

        public SubscriptionRepository(ITravelAgencyDbContext context)
        {
            this.context = context;
        }

        public async Task<DefaultResponseModel> AddAsycn(string subscriberEmail)
        {
            if (context.Subscribers.FirstOrDefault(subscriber => subscriber.Email == subscriberEmail) != null)
            {
                return new DefaultResponseModel
                {
                    IsSuccessful = false,
                    Message = "You have already subscribed to the newsletter."
                };
            }
            var insertionResult = await context.Subscribers.AddAsync(Map(subscriberEmail));
            context.SaveChanges();

            return new DefaultResponseModel
            {
                IsSuccessful = true,
                Message = "You have successfully subscribed to our newsletter. Stay in touch with news and hot offers from all around the world."
            };
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
