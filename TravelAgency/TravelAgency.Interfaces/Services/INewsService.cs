using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.Services
{
    public interface INewsService
    {
        Task<IReadOnlyCollection<NewsData>> GetAsync();

        Task<NewsData> GetAsync(int id);

        Task<IReadOnlyCollection<NewsData>> GetLatestAsync();
    }
}
