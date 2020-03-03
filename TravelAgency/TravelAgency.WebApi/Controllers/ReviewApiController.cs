using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.WebApi.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewApiController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewApiController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        [Route("getdetails/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Json(await reviewService.GetAsync(id));
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Json(await reviewService.GetAsync());
        }
    }
}
