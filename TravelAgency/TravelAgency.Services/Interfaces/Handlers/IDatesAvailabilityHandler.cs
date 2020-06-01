using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto.Models.Booking;

namespace TravelAgency.Services.Interfaces.Handlers
{
    public interface IDatesAvailabilityHandler
    {
        Task<bool> AreBookingDatesValid(AddOrderModel addOrderModel);
    }
}