using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Dto.Models.Account;
using TravelAgency.Interfaces.Dto.Models.LogIn;
using TravelAgency.Interfaces.Dto.Models.Register;

namespace TravelAgency.Interfaces.Services
{
    public interface IAccountService
    {
        Task<RegistrationResponseModel> RegisterAsync(RegistrationRequestModel registrationRequestModel);

        Task<LogInResponseModel> LogInAsync(LogInRequestModel logInRequestModel);

        Task<ClientAccountModel> GetClientAccountAsync(string token);

        Task LogoutAsync(SessionData data);
    }
}
