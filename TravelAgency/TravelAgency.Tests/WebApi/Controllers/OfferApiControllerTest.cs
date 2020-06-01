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
    internal class OfferApiControllerTest : UnitTestBase
    {
        private const string GetTopMethodName = nameof(OfferApiController.GetTop) + ". ";
        private const string GetDetailsMethodName = nameof(OfferApiController.GetDetails) + ". ";
        private const string GetAllMethodName = nameof(OfferApiController.GetAll) + ". ";
        private const string SearchMethodName = nameof(OfferApiController.Search) + ". ";
        private const int offerId = 1;

        private Mock<IOfferService> offerServiceMock;

        private OfferApiController offerApiController;

        [SetUp]
        public void TestInitialize()
        {
            offerServiceMock = MockRepository.Create<IOfferService>();
            offerApiController = new OfferApiController(offerServiceMock.Object);
        }

        [TestCase(TestName = GetTopMethodName + "Should return JSON form of result got from offerService GetTop method")]
        public async Task GetTopTest()
        {
            IReadOnlyCollection<OfferData> offerDataCollection = CreateOfferDataCollection();

            SetupOfferServiceGetTopMock(offerDataCollection);

            var actual = (JsonResult)await offerApiController.GetTop();

            Assert.AreEqual(offerApiController.Json(offerDataCollection).Value, actual.Value);
        }

        [TestCase(TestName = GetDetailsMethodName + "Should return JSON form of result got from offerService GetDetails method with id argument")]
        public async Task GetDetailsTest()
        {
            OfferData offerData = CreateOfferData();

            SetupOfferServiceGetByIdMock(offerId, offerData);

            var actual = (JsonResult)await offerApiController.GetDetails(offerId);

            Assert.AreEqual(offerApiController.Json(offerData).Value, actual.Value);
        }

        [TestCase(TestName = GetAllMethodName + "Should return JSON form of result got from offerService GetAll method")]
        public async Task GetAllTest()
        {
            IReadOnlyCollection<OfferData> offerDataCollection = CreateOfferDataCollection();

            SetupOfferServiceGetAllMock(offerDataCollection);

            var actual = (JsonResult)await offerApiController.GetAll();

            Assert.AreEqual(offerApiController.Json(offerDataCollection).Value, actual.Value);
        }

        [TestCase(TestName = SearchMethodName + "Should return JSON form of result got from offerService Search method")]
        public async Task SearchTest()
        {
            SearchData searchData = CreateSearchData();
            IReadOnlyCollection<OfferData> offerDataCollection = CreateOfferDataCollection();

            SetupOfferServiceGetSearchResultByPageMock(searchData, offerDataCollection);

            var actual = (JsonResult)await offerApiController.Search(searchData);

            Assert.AreEqual(offerApiController.Json(offerDataCollection).Value, actual.Value);
        }

        private void SetupOfferServiceGetTopMock(IReadOnlyCollection<OfferData> offerDataCollection)
            => offerServiceMock
                .Setup(service => service.GetTopAsync())
                .ReturnsAsync(offerDataCollection);

        private void SetupOfferServiceGetByIdMock(int id, OfferData offerData)
            => offerServiceMock
                .Setup(service => service.GetAsync(id))
                .ReturnsAsync(offerData);

        private void SetupOfferServiceGetAllMock(IReadOnlyCollection<OfferData> offerDataCollection)
            => offerServiceMock
                .Setup(service => service.GetAsync())
                .ReturnsAsync(offerDataCollection);

        private void SetupOfferServiceGetSearchResultByPageMock(SearchData searchData, IReadOnlyCollection<OfferData> offerDataCollection)
            => offerServiceMock
                .Setup(service => service.GetSearchResultByPageAsync(searchData))
                .ReturnsAsync(offerDataCollection);

        private IReadOnlyCollection<OfferData> CreateOfferDataCollection() => new List<OfferData>();

        private OfferData CreateOfferData() => new OfferData();

        private SearchData CreateSearchData() => new SearchData();
    }
}