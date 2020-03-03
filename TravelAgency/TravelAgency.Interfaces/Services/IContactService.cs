using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.Services
{
    public interface IContactService
    {
        void ContactManager(EmailData emailData);
    }
}
