using System;
using System.Collections.Generic;
using System.Text;
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

        public void ContactManager(EmailData emailData)
        {
            string receiver = "manager@gmail.com";

            mailHandler.SendMailAsync(emailData, receiver);
        }
    }
}
