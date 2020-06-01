using System;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto.Models.Booking;
using TravelAgency.Services.Interfaces.Handlers;

namespace TravelAgency.Services.Handlers
{
    internal class DatesAvailabilityHandler : IDatesAvailabilityHandler
    {
        public async Task<bool> AreBookingDatesValid(AddOrderModel addOrderModel)
            => DateTime.Compare(addOrderModel.CheckOut, addOrderModel.CheckIn) > 0 &&
               DateTime.Compare(addOrderModel.CheckIn, DateTime.UtcNow) > 0;
        

        private bool IsDatesOverlay(DateTime checkIn1, DateTime checkOut1, DateTime checkIn2, DateTime checkOut2)
        {
            return DateTime.Compare(checkIn1, checkOut2) < 0 && DateTime.Compare(checkOut1, checkIn2) > 0;
        }
    }
}