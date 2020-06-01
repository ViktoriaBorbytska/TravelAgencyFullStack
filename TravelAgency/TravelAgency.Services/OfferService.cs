using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.Services
{
    internal class OfferService : IOfferService
    {
        private const int DefaultPageSize = 20;
        private readonly IOfferRepository offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task<IReadOnlyCollection<OfferData>> GetAsync() => await offerRepository.GetAsync();

        public async Task<OfferData> GetAsync(int id) => await offerRepository.GetAsync(id);

        public async Task<IReadOnlyCollection<OfferData>> GetTopAsync() => await offerRepository.GetTopAsync();

        public async Task<IReadOnlyCollection<OfferData>> GetSearchResultByPageAsync(SearchData searchData) =>
            searchData == null
                ? await offerRepository.GetByPageAsync(1, DefaultPageSize)
                : await offerRepository.GetSearchResultByPageAsync(searchData, DefaultPageSize);
    }
}
