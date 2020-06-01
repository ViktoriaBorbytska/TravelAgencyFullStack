using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Dto.Models;
using TravelAgency.Interfaces.Dto.Models.Booking;
using TravelAgency.Interfaces.Services;
using TravelAgency.Services.Interfaces.Handlers;

namespace TravelAgency.Services
{
    public class BookingService : IBookingService
    {
        private readonly IDatesAvailabilityHandler datesAvailabilityHandler;
        private readonly IOfferRepository offerRepository;
        private readonly IBookingRepository bookingRepository;
        private readonly IClientRepository clientRepository;
        private readonly ISessionRepository sessionRepository;
        private readonly IApplicationUserRepository applicationUserRepository;
        private const double ChildrenСoefficient = 0.7;

        public BookingService(
            IDatesAvailabilityHandler datesAvailabilityHandler,
            IOfferRepository offerRepository,
            IBookingRepository bookingRepository,
            IClientRepository clientRepository,
            ISessionRepository sessionRepository,
            IApplicationUserRepository applicationUserRepository)
        {
            this.datesAvailabilityHandler = datesAvailabilityHandler;
            this.offerRepository = offerRepository;
            this.bookingRepository = bookingRepository;
            this.clientRepository = clientRepository;
            this.sessionRepository = sessionRepository;
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task<IReadOnlyCollection<GetOrderModel>> GetAsync() => await bookingRepository.GetAsync();

        public async Task<GetOrderModel> GetAsync(int id) => await bookingRepository.GetAsync(id);

        public async Task<IReadOnlyCollection<GetOrderModel>> GetByClientAsync(string token)
        {
            SessionData session = await sessionRepository.GetByTokenAsync(token);
            ClientData clientData = await clientRepository.FindByIdAsync(session.UserId);
            return (await clientRepository.FindByIdAsync(clientData.Id) != null)
                ? await bookingRepository.GetByClientAsync(clientData.Id)
                : new List<GetOrderModel>();
        }

        public async Task<DefaultResponseModel> AddAsync(AddOrderModel addOrderModel)
        {
            DefaultResponseModel response = new DefaultResponseModel { IsSuccessful = false, Message = string.Empty };
            SessionData session = await sessionRepository.GetByTokenAsync(addOrderModel.Token);
            if (session == null)
            {
                response.Message = "Unauthorized user";
                return response;
            }
            if (!await datesAvailabilityHandler.AreBookingDatesValid(addOrderModel))
            {
                response.Message = "Dates are not valid";
                return response;
            }

            UserData user = await applicationUserRepository.FindByIdAsync(session.UserId);
            ClientData client = clientRepository.FindByUser(user);
            var orderData = new OrderData
            {
                OfferId = addOrderModel.OfferId,
                ClientId = client.Id,
                IsBooked = false,
                ChildrenCount = addOrderModel.ChildrenCount,
                AdultCount = addOrderModel.AdultCount,
                Price = addOrderModel.Price,
                CheckIn = addOrderModel.CheckIn,
                CheckOut = addOrderModel.CheckOut,
            };
            
            OrderData addedOrder = await bookingRepository.AddAsync(orderData);

            response.IsSuccessful = true;
            return response;
        }
        
        public async Task<DefaultResponseModel> BookAsync(BookOrderModel bookOrderModel)
        {
            DefaultResponseModel response = new DefaultResponseModel { IsSuccessful = false, Message = string.Empty };
            SessionData session = await sessionRepository.GetByTokenAsync(bookOrderModel.Token);
            
            if (session == null)
            {
                response.Message = "Unauthorized user";
                return response;
            }

            await bookingRepository.BookAsync(bookOrderModel.OrderId);
            response.IsSuccessful = true;

            return response;
        }

        public async Task<DefaultResponseModel> DeleteAsync(BookOrderModel bookOrderModel)
        {
            DefaultResponseModel response = new DefaultResponseModel { IsSuccessful = false, Message = string.Empty };
            SessionData session = await sessionRepository.GetByTokenAsync(bookOrderModel.Token);
            
            if (session == null)
            {
                response.Message = "Unauthorized user";
                return response;
            }

            await bookingRepository.DeleteAsync(bookOrderModel.OrderId);

            return response;
        }
    }
}