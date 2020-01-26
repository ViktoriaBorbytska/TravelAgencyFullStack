using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Entities.Users;

namespace TravelAgency.DatabaseAccess.Interfaces
{
    internal interface IApplicationDBContext
    {
        DbSet<Order> Orders { get; set; }

        DbSet<Offer> Offers { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<Session> Sessions { get; set; }

        DbSet<Subscription> Subscriptions { get; set; }

        DbSet<Manager> Managers { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<News> News { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        int SaveChanges();
    }
}
