using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Interfaces.Dto.Models.Booking;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.WebApi.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingApiController : Controller
    {
        private readonly IBookingService bookingService;
        
        public BookingApiController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        
        [Route("of-client/{token}")]
        [HttpGet] 
        public async Task<IActionResult> GetByClient(string token) => Json(await bookingService.GetByClientAsync(token));
        
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderModel addOrderModel)
            => Json(await bookingService.AddAsync(addOrderModel));

        [Route("book")]
        [HttpPost]
        public async Task<IActionResult> Book(BookOrderModel bookOrderModel)
            => Json(await bookingService.BookAsync(bookOrderModel));

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(BookOrderModel bookOrderModel)
            => Json(await bookingService.DeleteAsync(bookOrderModel));
    }
}