using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Services;
using TravelAgency.Services.Interfaces.Handlers;

namespace TravelAgency.Services
{
    internal class ContactService : IContactService
    { 
        private readonly IMailHandler mailHandler;

        public ContactService(IMailHandler mailHandler)
        {
            this.mailHandler = mailHandler;
        }

        public async Task ContactManagerAsync(EmailData emailData)
        {
            string receiver = "manager@gmail.com";

            await mailHandler.SendMailAsync(emailData, receiver);
        }
    }
}
