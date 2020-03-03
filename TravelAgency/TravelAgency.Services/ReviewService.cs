using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.Services
{
    internal class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public async Task<IReadOnlyCollection<ReviewData>> GetAsync() => await reviewRepository.GetAsync();

        public async Task<ReviewData> GetAsync(int id) => await reviewRepository.GetAsync(id);
    }
}
