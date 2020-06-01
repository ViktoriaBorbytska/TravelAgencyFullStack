using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.Services
{
    public interface IReviewService
    {
        Task<IReadOnlyCollection<ReviewData>> GetAsync();

        Task<ReviewData> GetAsync(int id);
    }
}
