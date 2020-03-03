using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Dto.Models;
using TravelAgency.Interfaces.Services;
using TravelAgency.Services.Interfaces.Handlers;

namespace TravelAgency.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository subscriptionRepository;
        private readonly IMailHandler mailHandler;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IMailHandler mailHandler)
        {
            this.subscriptionRepository = subscriptionRepository;
            this.mailHandler = mailHandler;
        }

        public async Task AddAsync(string subscriberEmail)
        {
            await subscriptionRepository.AddAsycn(subscriberEmail);
        }

        public async Task SendEmailAsync()
        {
            IReadOnlyCollection<SubscriberData> subscribers = await subscriptionRepository.GetAsync();

            string newsLink = "https://www.google.com.ua";
            string message = "<p>Hey! Check out our latest news by the link below: " +
                $"<a href='{newsLink}'>Link</a></p>";
            string name = "Carpe diem travel agency";
            string email = "carpediem@travel.agency";
            string subject = "Latest news";

            foreach (var subscriber in subscribers)
            {
                EmailData emailData = new EmailData
                {
                    Message = message,
                    Email = email,
                    Name = name,
                    Subject = subject
                };

                await mailHandler.SendMailAsync(emailData, subscriber.Email);
            }
        }
    }
}
