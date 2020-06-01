using System.Threading.Tasks;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Services.Handlers;
using Moq;
using NUnit.Framework;

namespace TravelAgency.Tests.Service.Handlers
{
    [TestFixture]
    internal class SessionHandlerTest : UnitTestBase
    {
        private const string GetUserMethodName = nameof(SessionHandler.GetUserAsync) + ". ";
        private const string Token = "Token";
        private const int UserId = 3;

        private SessionHandler sessionHandler;

        private Mock<IApplicationUserRepository> applicationUserRepositoryMock;
        private Mock<ISessionRepository> sessionRepositoryMock;
        private Mock<IClientRepository> clientRepositoryMock;

        [SetUp]
        public void TestInitialize()
        {
            applicationUserRepositoryMock = MockRepository.Create<IApplicationUserRepository>();
            sessionRepositoryMock = MockRepository.Create<ISessionRepository>();
            clientRepositoryMock = MockRepository.Create<IClientRepository>();
            sessionHandler = new SessionHandler(applicationUserRepositoryMock.Object, sessionRepositoryMock.Object, clientRepositoryMock.Object);
        }

        [TestCase(TestName = GetUserMethodName + "Should return valid ClientData")]
        public async Task GetUserTest()
        {
            SessionData sessionData = CreateSessionData();
            UserData userData = CreateUserData();
            ClientData expected = CreateClientData();

            SetupSessionRepositoryMock(sessionData);
            SetupApplicationUserRepositoryMock(sessionData, userData);
            SetupClientRepositoryMock(userData, expected);

            ClientData actual = await sessionHandler.GetUserAsync(Token);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(TestName = GetUserMethodName + "Should return null when SessionData is null")]
        public async Task GetClientNullSessionTest()
        {
            SetupSessionRepositoryMock(null);

            ClientData actual = await sessionHandler.GetUserAsync(Token);

            Assert.IsNull(actual);
        }

        [TestCase(TestName = GetUserMethodName + "Should return null when UserData is null")]
        public async Task GetClientNullUserTest()
        {
            SessionData sessionData = CreateSessionData();
            SetupSessionRepositoryMock(sessionData);
            SetupApplicationUserRepositoryMock(sessionData, null);

            ClientData actual = await sessionHandler.GetUserAsync(Token);

            Assert.IsNull(actual);
        }

        private void SetupSessionRepositoryMock(SessionData sessionData)
            => sessionRepositoryMock
                .Setup(repository => repository.GetByTokenAsync(Token))
                .ReturnsAsync(sessionData);

        private void SetupApplicationUserRepositoryMock(SessionData sessionData, UserData userData)
            => applicationUserRepositoryMock
                .Setup(repository => repository.FindByIdAsync(sessionData.UserId))
                .ReturnsAsync(userData);

        private void SetupClientRepositoryMock(UserData userData, ClientData clientData)
            => clientRepositoryMock
                .Setup(repository => repository.FindByUser(userData))
                .Returns(clientData);

        private SessionData CreateSessionData()
            => new SessionData { UserId = UserId };

        private UserData CreateUserData()
            => new UserData();

        private ClientData CreateClientData()
            => new ClientData();
    }
}