using System.Threading.Tasks;
using TravelAgency.DatabaseAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using TravelAgency.DatabaseAccess.Entities.Identity;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.DatabaseAccess.Repositories
{
    internal class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<User> userManager;
        private readonly ITravelAgencyDbContext applicationDbContext;

        public ApplicationUserRepository(UserManager<User> userManager, ITravelAgencyDbContext applicationDbContext)
        {
            this.userManager = userManager;
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IdentityResult> CreateAsync(UserData userData)
            => await userManager.CreateAsync(AddNameAsEmail(Map(userData)), userData.Password);

        public async Task<UserData> FindByEmailAsync(string email)
            => Map(await userManager.FindByEmailAsync(email.Normalize()));

        public async Task<UserData> FindByIdAsync(int id)
            => Map(await userManager.FindByIdAsync(id.ToString()));

        public async Task<bool> CheckPasswordAsync(string email, string password)
            => await userManager.CheckPasswordAsync(
                    await userManager.FindByEmailAsync(email.Normalize()), password);

        public async Task<IdentityResult> UpdateAsync(UserData userData, string newEmail)
        {
            var user = await userManager.FindByEmailAsync(userData.Email.Normalize());

            var emailChanged = await ChangeEmailAsync(user, newEmail);
            await userManager.UpdateNormalizedEmailAsync(user);
            var result = await userManager.UpdateAsync(user);

            await applicationDbContext.SaveChangesAsync();

            return result;
        }

        private async Task<IdentityResult> ChangeEmailAsync(User user, string newEmail)
        {
            string token = await userManager.GenerateChangeEmailTokenAsync(user, newEmail);
            var res = await userManager.ChangeEmailAsync(user, newEmail, token);

            return res;
        }

        private UserData Map(User user)
           => (user == null) ? null : new UserData
           {
               Id = user.Id,
               Email = user.Email,
               RoleId = user.RoleId,
               Password = user.PasswordHash
           };

        private User Map(UserData data)
          => (data == null) ? null : new User
          {
              Id = data.Id,
              Email = data.Email,
              RoleId = data.RoleId
          };

        private User AddNameAsEmail(User user)
        {
            user.UserName = user.Email;
            return user;
        }
    }
}