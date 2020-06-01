using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface IOfferRepository
    {
        Task<IReadOnlyCollection<OfferData>> GetAsync();

        Task<OfferData> GetAsync(int id);

        Task<IReadOnlyCollection<OfferData>> GetTopAsync();

        Task<IReadOnlyCollection<OfferData>> GetByPageAsync(int page, int pageSize);

        Task<IReadOnlyCollection<OfferData>> GetSearchResultByPageAsync(SearchData searchData, int pageSize);
    }
}
