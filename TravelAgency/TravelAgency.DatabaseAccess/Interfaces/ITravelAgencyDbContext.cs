using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Entities.Users;

namespace TravelAgency.DatabaseAccess.Interfaces
{
    internal interface ITravelAgencyDbContext
    {
        DbSet<Order> Orders { get; set; }

        DbSet<Offer> Offers { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<Session> Sessions { get; set; }

        DbSet<Subscriber> Subscribers { get; set; }

        DbSet<Manager> Managers { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<News> News { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        int SaveChanges();
    }
}
