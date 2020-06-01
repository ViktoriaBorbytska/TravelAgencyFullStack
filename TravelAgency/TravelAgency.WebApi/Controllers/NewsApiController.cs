using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.WebApi.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsApiController : Controller
    {
        private readonly INewsService newsService;

        public NewsApiController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet]
        [Route("getdetails/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Json(await newsService.GetAsync(id));
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Json(await newsService.GetAsync());
        }

        [HttpGet]
        [Route("getlatest")]
        public async Task<IActionResult> GetLatest()
        {
            return Json("");// await newsService.GetAsync());
        }
    }
}
