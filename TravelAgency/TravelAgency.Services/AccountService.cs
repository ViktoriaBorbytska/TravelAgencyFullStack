using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Dto.Models.Account;
using TravelAgency.Interfaces.Dto.Models.LogIn;
using TravelAgency.Interfaces.Dto.Models.Register;
using TravelAgency.Interfaces.Services;
using TravelAgency.Services.Interfaces;
using TravelAgency.Services.Interfaces.Factories;
using TravelAgency.Services.Interfaces.Handlers;

namespace TravelAgency.Services
{
    internal class AccountService : IAccountService
    {
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly ISessionRepository sessionRepository;
        private readonly IJavascriptWebTokenFactory javascriptWebTokenFactory;
        private readonly IClientRepository clientRepository;
        private readonly IApplicationRoleRepository applicationRoleRepository;
        private readonly ISessionHandler sessionHandler;

        public AccountService(
            IApplicationUserRepository applicationUserRepository,
            ISessionRepository sessionRepository,
            IClientRepository clientRepository,
            IJavascriptWebTokenFactory javascriptWebTokenFactory,
            IApplicationRoleRepository applicationRoleRepository,
            ISessionHandler sessionHandler)
        {
            this.applicationUserRepository = applicationUserRepository;
            this.sessionRepository = sessionRepository;
            this.javascriptWebTokenFactory = javascriptWebTokenFactory;
            this.clientRepository = clientRepository;
            this.applicationRoleRepository = applicationRoleRepository;
            this.sessionHandler = sessionHandler;
        }

        public async Task<RegistrationResponseModel> RegisterAsync(RegistrationRequestModel registrationModel)
        {
            RoleData role = applicationRoleRepository.Get(registrationModel.Role);
            RegistrationResponseModel response = new RegistrationResponseModel() { IsSuccessful = false, Message = string.Empty };
            var userData = new UserData
            {
                Email = registrationModel.Email,
                Password = registrationModel.Password,
                RoleId = role.Id
            };

            IdentityResult userCreatingResult = await applicationUserRepository.CreateAsync(userData);
            if (!userCreatingResult.Succeeded)
            {
                // pushing message of first error in array
                response.Message = GetErrorMessage(userCreatingResult);
                return response;
            }

            userData = await applicationUserRepository.FindByEmailAsync(userData.Email);
            ClientData client = new ClientData()
            {
                Name = registrationModel.UserName,
                Surname = registrationModel.Surname,
                PhotoPath = "default/profile.png",
                UserId = userData.Id,
                Phone = registrationModel.Phone
            };
            ClientData addedClient = await clientRepository.AddAsync(client);
            if (addedClient == null)
            {
                response.Message = "Client not added";
            }
            response.IsSuccessful = true;
            string token = javascriptWebTokenFactory.Create(userData.Id);
            var sessionData = new SessionData
            {
                UserId = userData.Id,
                Token = token,
            };
            await sessionRepository.CreateAsync(sessionData);
            response.Token = token;
            return response;
        }

        public async Task<LogInResponseModel> LogInAsync(LogInRequestModel logInRequestModel)
        {
            var response = new LogInResponseModel { IsSuccessful = false };

            UserData userData = await applicationUserRepository.FindByEmailAsync(logInRequestModel.Email.Normalize());

            if (userData == null)
            {
                response.Message = "Account with this email doesn`t exists";
            }
            else if (!await applicationUserRepository.CheckPasswordAsync(
                logInRequestModel.Email,
                logInRequestModel.Password))
            {
                response.Message = "Wrong Password";
            }
            else
            {
                string token = javascriptWebTokenFactory.Create(userData.Id);
                var sessionDto = new SessionData
                {
                    UserId = userData.Id,
                    Token = token
                };
                await sessionRepository.CreateAsync(sessionDto);
                response.Token = token;
                response.IsSuccessful = true;
            }
            return response;
        }

        public async Task<ClientAccountModel> GetClientAccountAsync(string token)
        {
            SessionData session = await sessionRepository.GetByTokenAsync(token);
            UserData user = await applicationUserRepository.FindByIdAsync(session.UserId);
            ClientData client = clientRepository.FindByUser(user);
            var account = new ClientAccountModel()
            {
                ClientId = client.Id,
                Email = user.Email,
                Passport = client.Passport,
                Telephone = client.Phone,
                Name = client.Name,
                Surname = client.Surname,
                PhotoPath = client.PhotoPath,
                Role = applicationRoleRepository.Get(user.RoleId).Name
            };
            return account;
        }

        public async Task LogoutAsync(SessionData sessionData) => await sessionRepository.RemoveAsync(sessionData);

        private string GetErrorMessage(IdentityResult identityResult)
        {
            // return first error in list
            var errorsEnumarator = identityResult.Errors.GetEnumerator();
            errorsEnumarator.MoveNext();
            return errorsEnumarator.Current.Description;
        }
    }
}
