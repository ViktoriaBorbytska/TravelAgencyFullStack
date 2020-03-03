using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.WebApi.Controllers
{
    [Route("api/subscription")]
    [ApiController]
    public class SubscriptionApiController : Controller
    {
        private readonly ISubscriptionService subscriptionService;

        public SubscriptionApiController(ISubscriptionService subscriptionService)
        {
            this.subscriptionService = subscriptionService;
        }

        [HttpGet]
        [Route("send")]
        public async Task<IActionResult> GetAll()
        {
            await subscriptionService.SendEmailAsync();

            return Json("Probably sent ¯\\_(ツ)_/¯ ");
        }
    }
}
