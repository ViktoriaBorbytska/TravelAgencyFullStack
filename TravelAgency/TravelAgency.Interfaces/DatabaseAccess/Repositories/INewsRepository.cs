using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface INewsRepository
    {
        Task<IReadOnlyCollection<NewsData>> GetAsync();

        Task<NewsData> GetAsync(int id);

        Task<IReadOnlyCollection<NewsData>> GetLatestAsync();

        Task<IReadOnlyCollection<NewsData>> GetByPageAsync(int page, int pageSize);

        Task<NewsData> AddAsycn(NewsData newsData);
    }
}
