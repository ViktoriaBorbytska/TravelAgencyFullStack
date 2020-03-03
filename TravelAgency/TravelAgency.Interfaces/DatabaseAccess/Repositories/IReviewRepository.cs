using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface IReviewRepository
    {
        Task<IReadOnlyCollection<ReviewData>> GetAsync();

        Task<ReviewData> GetAsync(int id);
    }
}
