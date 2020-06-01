using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TravelAgency.Interfaces.Dto.Models;
using TravelAgency.Interfaces.Services;
using TravelAgency.WebApi.Controllers;

namespace TravelAgency.Tests.WebApi.Controllers
{
    [TestFixture]
    internal class SubscriptionApiControllerTest : UnitTestBase
    {
        private const string SendEmailMethodName = nameof(SubscriptionApiController.SendEmail) + ". ";
        private const string SubscribeMethodName = nameof(SubscriptionApiController.Subscribe) + ". ";

        private Mock<ISubscriptionService> subscriptionServiceMock;

        private SubscriptionApiController subscriptionApiController;

        [SetUp]
        public void TestInitialize()
        {
            subscriptionServiceMock = MockRepository.Create<ISubscriptionService>();
            subscriptionApiController = new SubscriptionApiController(subscriptionServiceMock.Object);
        }

        [TestCase(TestName = SendEmailMethodName + "Should return JSON form of result got from subscriptionService SendEmail method")]
        public async Task SendEmailTest()
        {
            string expected = "Letters have been successfully sent.";

            SetupSubscriptionServiceSendEmailMock();

            var actual = (JsonResult)await subscriptionApiController.SendEmail();

            Assert.AreEqual(expected, actual.Value);
        }

        [TestCase(TestName = SubscribeMethodName + "Should return JSON form of result got from subscriptionService Subscribe method")]
        public async Task SubscribeTest()
        {
            string email = "email@email.com";
            DefaultResponseModel defaultResponseModel = CreateDefaultResponseModel();

            SetupSubscriptionServiceSubscribeMock(email, defaultResponseModel);

            var actual = (JsonResult)await subscriptionApiController.Subscribe(email);

            Assert.AreEqual(subscriptionApiController.Json(defaultResponseModel).Value, actual.Value);
        }

        private void SetupSubscriptionServiceSendEmailMock()
               => subscriptionServiceMock
                   .Setup(service => service.SendEmailAsync())
                   .Returns(Task.CompletedTask);

        private void SetupSubscriptionServiceSubscribeMock(string email, DefaultResponseModel defaultResponseModel)
               => subscriptionServiceMock
                   .Setup(service => service.AddAsync(email))
                   .ReturnsAsync(defaultResponseModel);

        private DefaultResponseModel CreateDefaultResponseModel()
            => new DefaultResponseModel();
    }
}