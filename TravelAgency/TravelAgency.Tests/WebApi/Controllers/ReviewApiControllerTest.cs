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
    internal class ReviewApiControllerTest : UnitTestBase
    {
        private const string GetAllMethodName = nameof(ReviewApiController.GetAll) + ". ";
        private const string GetDetailsMethodName = nameof(ReviewApiController.GetDetails) + ". ";

        private const int reviewId = 200;

        private Mock<IReviewService> reviewServiceMock;

        private ReviewApiController reviewApiController;

        [SetUp]
        public void TestInitialize()
        {
            reviewServiceMock = MockRepository.Create<IReviewService>();
            reviewApiController = new ReviewApiController(reviewServiceMock.Object);
        }

        [TestCase(TestName = GetAllMethodName + "Should return JSON form of result got from reviewService GetTop method")]
        public async Task GetAllTest()
        {
            IReadOnlyCollection<ReviewData> reviewDataCollection = CreateReviewDataCollection();

            SetupReviewServiceGetAllMock(reviewDataCollection);

            var actual = (JsonResult)await reviewApiController.GetAll();

            Assert.AreEqual(reviewApiController.Json(reviewDataCollection).Value, actual.Value);
        }

        [TestCase(TestName = GetDetailsMethodName + "Should return JSON form of result got from reviewService GetDetails method")]
        public async Task GetDetailsTest()
        {
            ReviewData reviewData = CreateReviewData();

            SetupReviewServiceGetByIdMock(reviewId, reviewData);

            var actual = (JsonResult)await reviewApiController.GetDetails(reviewId);

            Assert.AreEqual(reviewApiController.Json(reviewData).Value, actual.Value);
        }

        private void SetupReviewServiceGetByIdMock(int id, ReviewData reviewData)
            => reviewServiceMock
                .Setup(service => service.GetAsync(id))
                .ReturnsAsync(reviewData);

        private void SetupReviewServiceGetAllMock(IReadOnlyCollection<ReviewData> reviewDataCollection)
            => reviewServiceMock
                .Setup(service => service.GetAsync())
                .ReturnsAsync(reviewDataCollection);

        private ReviewData CreateReviewData()
            => new ReviewData();

        private IReadOnlyCollection<ReviewData> CreateReviewDataCollection()
            => new List<ReviewData>();
    }
}