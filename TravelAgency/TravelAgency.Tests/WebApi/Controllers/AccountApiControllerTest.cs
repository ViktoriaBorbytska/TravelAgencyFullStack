using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Dto.Models;
using TravelAgency.Interfaces.Dto.Models.Account;
using TravelAgency.Interfaces.Dto.Models.LogIn;
using TravelAgency.Interfaces.Dto.Models.Register;
using TravelAgency.Interfaces.Services;
using TravelAgency.WebApi.Controllers;

namespace TravelAgency.Tests.WebApi.Controllers
{
    [TestFixture]
    internal class AccountApiControllerTest : UnitTestBase
    {
        private const string RegisterMethodName = nameof(AccountApiController.Register) + ". ";
        private const string LoginMethodName = nameof(AccountApiController.Login) + ". ";
        private const string LogoutMethodName = nameof(AccountApiController.Logout) + ". ";
        private const string GetClientAccountMethodName = nameof(AccountApiController.GetClientAccount) + ". ";

        private const int StatusCode = 200;
        private const string Token = "Token";
        private const bool Successful = true;

        private Mock<IAccountService> accountServiceMock;

        private AccountApiController accountApiController;

        [SetUp]
        public void TestInitialize()
        {
            accountServiceMock = MockRepository.Create<IAccountService>();
            accountApiController = new AccountApiController(accountServiceMock.Object);
        }

        [TestCase(TestName = RegisterMethodName + "Should return JSON form of result got from accountService Register method")]
        public async Task RegisterTest()
        {
            RegistrationRequestModel registrationRequestModel = CreateRegistrationRequestModel();
            RegistrationResponseModel expected = CreateRegistrationResponseModel();

            SetupAccountServiceRegisterMock(registrationRequestModel, expected);

            var actual = (JsonResult)await accountApiController.Register(registrationRequestModel);

            Assert.AreEqual(expected, actual.Value);
        }

        [TestCase(TestName = LoginMethodName + "Should return JSON form of result got from accountService Login method")]
        public async Task LoginTest()
        {
            LogInRequestModel logInRequestModel = CreateLogInRequestModel();
            LogInResponseModel expected = CreateLogInResponseModel();

            SetupAccountServiceLoginMock(logInRequestModel, expected);

            var actual = (JsonResult)await accountApiController.Login(logInRequestModel);

            Assert.AreEqual(expected, actual.Value);
        }

        [TestCase(TestName = LogoutMethodName + "Should return JSON form of result got from accountService Logout method")]
        public async Task LogoutTest()
        {
            SessionData sessionData = CreateSessionData();

            SetupAccountServiceLogoutMock(sessionData);

            var actual = await accountApiController.Logout(sessionData);

            Assert.AreEqual((actual as OkResult).StatusCode, StatusCode);
        }

        [TestCase(TestName = GetClientAccountMethodName + "Should return JSON form of result got from accountService GetClientAccount method")]
        public async Task GetClientAccountTest()
        {
            ClientAccountModel expected = CreateClientAccountModel();

            SetupAccountServiceGetClientAccountMock(Token, expected);

            var actual = (JsonResult)await accountApiController.GetClientAccount(Token);

            Assert.AreEqual(expected, actual.Value);
        }

        private void SetupAccountServiceGetClientAccountMock(string token, ClientAccountModel clientAccountModel)
               => accountServiceMock
                   .Setup(service => service.GetClientAccountAsync(token))
                   .ReturnsAsync(clientAccountModel);

        private void SetupAccountServiceLogoutMock(SessionData sessionData)
            => accountServiceMock
                .Setup(service => service.LogoutAsync(sessionData))
                .Returns(Task.FromResult(default(object)));

        private void SetupAccountServiceRegisterMock(RegistrationRequestModel registrationRequestModel, RegistrationResponseModel registrationResponseModel)
                => accountServiceMock
                    .Setup(service => service.RegisterAsync(registrationRequestModel))
                    .ReturnsAsync(registrationResponseModel);

        private void SetupAccountServiceLoginMock(LogInRequestModel logInRequestModel, LogInResponseModel logInResponseModel)
               => accountServiceMock
                   .Setup(service => service.LogInAsync(logInRequestModel))
                   .ReturnsAsync(logInResponseModel);

        private ClientAccountModel CreateClientAccountModel()
            => new ClientAccountModel();

        private DefaultResponseModel CreateDefaultResponseModel()
            => new DefaultResponseModel();

        private SessionData CreateSessionData()
            => new SessionData();

        private LogInResponseModel CreateLogInResponseModel()
            => new LogInResponseModel();

        private LogInRequestModel CreateLogInRequestModel()
            => new LogInRequestModel();

        private RegistrationResponseModel CreateRegistrationResponseModel()
            => new RegistrationResponseModel();

        private RegistrationRequestModel CreateRegistrationRequestModel()
            => new RegistrationRequestModel();
    }
}