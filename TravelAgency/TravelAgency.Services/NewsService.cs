using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.Services
{
    internal class NewsService : INewsService
    {
        private readonly INewsRepository newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task<IReadOnlyCollection<NewsData>> GetAsync() => await newsRepository.GetAsync();

        public async Task<NewsData> GetAsync(int id) => await newsRepository.GetAsync(id);

        public Task<IReadOnlyCollection<NewsData>> GetLatestAsync()
        {
            throw new NotImplementedException();
        }
    }
}
