using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Services;
using TravelAgency.WebApi.Controllers;

namespace TravelAgency.Tests.WebApi.Controllers
{
    [TestFixture]
    internal class NewsApiControllerTest : UnitTestBase
    {
        private const string GetDetailsMethodName = nameof(NewsApiController.GetDetails) + ". ";
        private const string GetAllMethodName = nameof(NewsApiController.GetAll) + ". ";
        private const string GetLatestMethodName = nameof(NewsApiController.GetLatest) + ". ";

        private const int newsId = 1;

        private Mock<INewsService> newsServiceMock;

        private NewsApiController newsApiController;

        [SetUp]
        public void TestInitialize()
        {
            newsServiceMock = MockRepository.Create<INewsService>();
            newsApiController = new NewsApiController(newsServiceMock.Object);
        }

        [TestCase(TestName = GetDetailsMethodName + "Should return JSON form of result got from newsService GetDetails method")]
        public async Task GetDetailsTest()
        {
            NewsData newsData = CreateNewsData();

            SetupNewsServiceGetByIdMock(newsId, newsData);

            var actual = (JsonResult)await newsApiController.GetDetails(newsId);

            Assert.AreEqual(newsApiController.Json(newsData).Value, actual.Value);
        }

        [TestCase(TestName = GetAllMethodName + "Should return JSON form of result got from newsService GetAll method")]
        public async Task GetAllTest()
        {
            IReadOnlyCollection<NewsData> newsDataCollection = CreateNewsDataCollection();

            SetupNewsServiceGetMock(newsDataCollection);

            var actual = (JsonResult)await newsApiController.GetAll();

            Assert.AreEqual(newsApiController.Json(newsDataCollection).Value, actual.Value);
        }

        [TestCase(TestName = GetLatestMethodName + "Should return JSON form of result got from newsService GetLatest method")]
        public async Task GetLatestTest()
        {
        //    SessionData sessionData = CreateSessionData();

        //    SetupAccountServiceLogoutMock(sessionData);

        //    var actual = await accountApiController.Logout(sessionData);

        //    Assert.AreEqual((actual as OkResult).StatusCode, StatusCode);
        }

        private void SetupNewsServiceGetByIdMock(int id, NewsData newsData)
               => newsServiceMock
                   .Setup(service => service.GetAsync(id))
                   .ReturnsAsync(newsData);

        private void SetupNewsServiceGetMock(IReadOnlyCollection<NewsData> newsDataCollection)
            => newsServiceMock
                .Setup(service => service.GetAsync())
                .ReturnsAsync(newsDataCollection);

        //private void SetupNewsServiceGetLatestMock(RegistrationRequestModel registrationRequestModel, RegistrationResponseModel registrationResponseModel)
        //        => newsServiceMock
        //            .Setup(service => service.GetLatestAsync())
        //            .ReturnsAsync(registrationResponseModel);

        private NewsData CreateNewsData()
            => new NewsData();

        private IReadOnlyCollection<NewsData> CreateNewsDataCollection()
            => new List<NewsData>();
    }
}