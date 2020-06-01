using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface IApplicationUserRepository
    {
        Task<IdentityResult> CreateAsync(UserData userDto);

        Task<UserData> FindByEmailAsync(string email);

        Task<UserData> FindByIdAsync(int id);

        Task<bool> CheckPasswordAsync(string email, string password);

        Task<IdentityResult> UpdateAsync(UserData user, string newEmail);
    }
}