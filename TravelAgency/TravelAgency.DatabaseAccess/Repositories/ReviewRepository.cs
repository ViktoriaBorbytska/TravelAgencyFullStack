using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.DatabaseAccess.Repositories
{
    internal class ReviewRepository : IReviewRepository
    {
        private readonly ITravelAgencyDbContext context;

        public ReviewRepository(ITravelAgencyDbContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyCollection<ReviewData>> GetAsync()
        {
            return Map(await context.Reviews.ToListAsync());
        }

        public async Task<ReviewData> GetAsync(int id)
        {
            Review review = await context.Reviews.FindAsync(id);
            return review == null ? null : Map(review);
        }

        private IReadOnlyCollection<ReviewData> Map(IReadOnlyCollection<Review> offer)
            => offer.Select(Map).ToList();

        private Review Map(ReviewData newsData)
             => new Review
             {
                 Id = newsData.Id,
                 UserId = newsData.UserId,
                 Header = newsData.Header,
                 Text = newsData.Text,
                 ImageLink = newsData.ImageLink,
                 Date = newsData.Date
             };

        private ReviewData Map(Review news)
             => new ReviewData
             {
                 Id = news.Id,
                 UserId = news.UserId,
                 Header = news.Header,
                 Text = news.Text,
                 ImageLink = news.ImageLink,
                 Date = news.Date
             };
    }
}
