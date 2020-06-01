using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto.Models;
using TravelAgency.Interfaces.Dto.Models.Booking;

namespace TravelAgency.Interfaces.Services
{
    public interface IBookingService
    {
        Task<IReadOnlyCollection<GetOrderModel>> GetAsync();

        Task<GetOrderModel> GetAsync(int id);

        Task<IReadOnlyCollection<GetOrderModel>> GetByClientAsync(string token);

        Task<DefaultResponseModel> AddAsync(AddOrderModel orderModel);
        
        Task<DefaultResponseModel> BookAsync(BookOrderModel bookOrderModel);

        Task<DefaultResponseModel> DeleteAsync(BookOrderModel bookOrderModel);
    }
}