using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.WebApi.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactApiController : Controller
    {
        private readonly IContactService contactService;

        public ContactApiController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpPut]
        [Route("contactmanager")]
        public async Task<IActionResult> Contact(EmailData emailData)
        {
            await contactService.ContactManagerAsync(emailData);

            return Ok();
        }
    }
}
