using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Entities.Users;
using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Dto.Models.Booking;

namespace TravelAgency.DatabaseAccess.Repositories
{
    internal class BookingRepository : IBookingRepository
    {
        private readonly ITravelAgencyDbContext context;

        public BookingRepository(ITravelAgencyDbContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyCollection<GetOrderModel>> GetAsync() => GetMap(await context.Orders.ToListAsync());

        public async Task<GetOrderModel> GetAsync(int id) => GetMap(await context.Orders.FindAsync(id));

        public async Task<IReadOnlyCollection<GetOrderModel>> GetByClientAsync(int id) =>
            GetMap(await context.Orders.Where(order => order.ClientId == id).ToListAsync());

        public async Task<OrderData> AddAsync(OrderData orderData)
        {
            var addingResult = await context.Orders.AddAsync(Map(orderData));
            context.SaveChanges();
            return Map(addingResult.Entity);
        }

        public async Task BookAsync(int orderId)
        {
            var order = await context.Orders.FirstOrDefaultAsync(ord => ord.Id == orderId);
            order.IsBooked = true;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderId)
        {
            var order = await context.Orders.FirstOrDefaultAsync(ord => ord.Id == orderId);
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }
        
        private GetOrderModel GetMap(Order order, Client client) 
            => new GetOrderModel
            {
                Id = order.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                OfferId = order.OfferId,
                AdultCount = order.AdultCount,
                ChildrenCount = order.ChildrenCount,
                CheckIn = order.CheckIn,
                CheckOut = order.CheckOut,
                Price = order.Price,
                IsBooked = order.IsBooked,
            };

        private GetOrderModel GetMap(Order order) 
            => new GetOrderModel
            {
                Id = order.Id,
                OfferId = order.OfferId,
                AdultCount = order.AdultCount,
                ChildrenCount = order.ChildrenCount,
                CheckIn = order.CheckIn,
                CheckOut = order.CheckOut,
                Price = order.Price,
                IsBooked = order.IsBooked,
            };

        private IReadOnlyCollection<GetOrderModel> GetMap(IReadOnlyCollection<Order> orders) => orders.Select(GetMap).ToList();

        private Order Map(OrderData orderData)
            => new Order
            {
                OfferId = orderData.OfferId,
                ClientId = orderData.ClientId,
                ChildrenCount = orderData.ChildrenCount,
                AdultCount = orderData.AdultCount,
                Price = orderData.Price,
                CheckIn = orderData.CheckIn,
                CheckOut = orderData.CheckOut,
                IsBooked = false
            };

        private OrderData Map(Order order)
            => new OrderData
            {
                OfferId = order.OfferId,
                AdultCount = order.AdultCount,
                ChildrenCount = order.ChildrenCount,
                CheckIn = order.CheckIn,
                CheckOut = order.CheckOut,
                Price = order.Price,
                IsBooked = order.IsBooked
            };
    }
}