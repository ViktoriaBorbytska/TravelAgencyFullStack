using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.WebApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomePageApiController : Controller
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "The server is working";
        }
    }
}
