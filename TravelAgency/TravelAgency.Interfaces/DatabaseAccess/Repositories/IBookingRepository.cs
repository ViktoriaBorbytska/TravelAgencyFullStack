using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Dto.Models.Booking;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface IBookingRepository
    {
        Task<IReadOnlyCollection<GetOrderModel>> GetAsync();

        Task<GetOrderModel> GetAsync(int id);

        Task<IReadOnlyCollection<GetOrderModel>> GetByClientAsync(int id);

        Task<OrderData> AddAsync(OrderData orderData);

        Task BookAsync(int orderId);

        Task DeleteAsync(int orderId);
    }
}