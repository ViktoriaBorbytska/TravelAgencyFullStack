using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.WebApi.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class OfferApiController : Controller
    {
        private readonly IOfferService offerService;

        public OfferApiController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpGet]
        [Route("gettop")]
        public async Task<IActionResult> GetTop() => Json(await offerService.GetTopAsync());
    
        [HttpGet]
        [Route("getdetails/{id}")]
        public async Task<IActionResult> GetDetails(int id) => Json(await offerService.GetAsync(id));

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll() => Json(await offerService.GetAsync());        

        [HttpPut]
        [Route("search")]
        public async Task<ActionResult> Search(SearchData searchData) => Json(await offerService.GetSearchResultByPageAsync(searchData));
    }
}
