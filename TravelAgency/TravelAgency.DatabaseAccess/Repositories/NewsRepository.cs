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
    internal class NewsRepository : INewsRepository
    {
        private readonly ITravelAgencyDbContext context;

        public NewsRepository(ITravelAgencyDbContext context)
        {
            this.context = context;
        }

        public async Task<NewsData> AddAsycn(NewsData newsData)
        {
            var insertionResult = await context.News.AddAsync(Map(newsData));
            context.SaveChanges();
            return Map(insertionResult.Entity);
        }

        public async Task<IReadOnlyCollection<NewsData>> GetAsync()
        {
            return Map(await context.News.ToListAsync());
        }

        public async Task<NewsData> GetAsync(int id)
        {
            News news = await context.News.FindAsync(id);
            return news == null ? null : Map(news);
        }

        public async Task<IReadOnlyCollection<NewsData>> GetByPageAsync(int page, int pageSize)
        {
            return Map(
            await context.News
                    .OrderBy(news => news.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }

        public Task<IReadOnlyCollection<NewsData>> GetLatestAsync()
        {
            throw new NotImplementedException();
        }

        private IReadOnlyCollection<NewsData> Map(IReadOnlyCollection<News> offer)
            => offer.Select(Map).ToList();

        private News Map(NewsData newsData)
             => new News
             {
                 Id = newsData.Id,
                 UserId = newsData.UserId,
                 Header = newsData.Header,
                 Text = newsData.Text,
                 ImageLink = newsData.ImageLink,
                 Date = newsData.Date
             };

        private NewsData Map(News news)
             => new NewsData
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
