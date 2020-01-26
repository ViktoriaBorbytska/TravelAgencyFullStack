using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Entities.Identity;
using TravelAgency.DatabaseAccess.Entities.Users;
using TravelAgency.DatabaseAccess.Interfaces;

namespace TravelAgency.DatabaseAccess
{
    class ApplicationDBContext : IdentityDbContext<User, IdentityRole<int>, int>, IApplicationDBContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Ignore(u => u.AccessFailedCount)
                                  .Ignore(u => u.NormalizedUserName)
                                  .Ignore(u => u.PhoneNumber)
                                  .Ignore(u => u.PhoneNumberConfirmed)
                                  .Ignore(u => u.TwoFactorEnabled);

            builder.Entity<Order>().HasKey(u => u.Id);
            builder.Entity<Manager>().HasKey(u => u.Id);
            builder.Entity<Offer>().HasKey(u => u.Id);
            builder.Entity<Review>().HasKey(u => u.Id);
            builder.Entity<Session>().HasKey(u => u.Id);
            builder.Entity<Order>().HasKey(u => u.Id);
            builder.Entity<Session>().HasKey(u => u.Id);
            builder.Entity<Subscription>().HasKey(u => u.Id);
            builder.Entity<News>().HasKey(u => u.Id);
            builder.Entity<Client>().HasKey(u => u.UserId);
        }
    }
}
