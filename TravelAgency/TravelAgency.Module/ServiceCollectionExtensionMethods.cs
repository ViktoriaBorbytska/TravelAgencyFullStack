using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelAgency.DatabaseAccess;
using TravelAgency.DatabaseAccess.Entities.Identity;
using TravelAgency.DatabaseAccess.Initializers;
using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.DatabaseAccess.Initializers;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.DatabaseAccess.Seeders;
using TravelAgency.Interfaces.Services;
using TravelAgency.Services;
using TravelAgency.Services.Factories;
using TravelAgency.Services.Handlers;
using TravelAgency.Services.Interfaces.Factories;
using TravelAgency.Services.Interfaces.Handlers;
using TravelAgency.Services.Interfaces.Providers;
using TravelAgency.Services.Providers;

namespace TravelAgency.Module
{
    public static class ServiceCollectionExtensionMethods
    {
        public static IConfiguration Configuration { get; }

        public static void AddTravelAgency(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            serviceCollection.AddTransient<ITravelAgencyDbContext, TravelAgencyDbContext>();
            serviceCollection.AddTransient<IDatabaseSeeder, DatabaseSeeder>();
            serviceCollection.AddTransient<JwtSecurityTokenHandler>();

            BindProviders(serviceCollection);
            BindFactories(serviceCollection);
            BindRepositories(serviceCollection);
            BindServices(serviceCollection);
            BindHandlers(serviceCollection);

            serviceCollection
                .AddIdentity<User, IdentityRole<int>>(options => { options.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<TravelAgencyDbContext>();

            serviceCollection.AddDbContext<TravelAgencyDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            serviceCollection.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            });
        }

        private static void BindHandlers(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMailHandler, MailHandler>();
            serviceCollection.AddTransient<ISessionHandler, SessionHandler>();
        }

        private static void BindProviders(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDateTimeProvider, DateTimeProvider>();
        }

        private static void BindFactories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IJavascriptWebTokenFactory, JavascriptWebTokenFactory>();
            serviceCollection.AddTransient<ISecurityTokenDescriptorFactory, SecurityTokenDescriptorFactory>();
        }

        private static void BindRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<INewsRepository, NewsRepository>();
            serviceCollection.AddTransient<IOfferRepository, OfferRepository>();
            serviceCollection.AddTransient<IReviewRepository, ReviewRepository>();
            serviceCollection.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
            serviceCollection.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
            serviceCollection.AddSingleton<IApplicationRoleRepository, ApplicationRoleRepository>();
            serviceCollection.AddTransient<IManagerRepository, ManagerRepository>();
            serviceCollection.AddTransient<IClientRepository, ClientRepository>();
            serviceCollection.AddTransient<ISessionRepository, SessionRepository>();
            //    serviceCollection.AddTransient<IHotelRepository, HotelRepository>();
            //    serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
            //    serviceCollection.AddTransient<IClientRepository, ClientRepository>();
            //    serviceCollection.AddTransient<IRoomRepository, RoomRepository>();
            //    serviceCollection.AddTransient<ICreditCardRepository, CreditCardRepository>();
        }

        private static void BindServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<INewsService, NewsService>();
            serviceCollection.AddTransient<IOfferService, OfferService>();
            serviceCollection.AddTransient<IReviewService, ReviewService>();
            serviceCollection.AddTransient<ISubscriptionService, SubscriptionService>();
            serviceCollection.AddTransient<IContactService, ContactService>();
            serviceCollection.AddTransient<IAccountService, AccountService>();
            //    serviceCollection.AddTransient<IHotelService, HotelService>();
            //    serviceCollection.AddTransient<IRoomService, RoomService>();
            //    serviceCollection.AddTransient<IOrderService, OrderService>();
            //    serviceCollection.AddTransient<IImageService, ImageService>();
        }
    }
}