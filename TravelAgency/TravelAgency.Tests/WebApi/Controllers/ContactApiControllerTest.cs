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
    internal class ContactApiControllerTest : UnitTestBase
    {
        private const string ContactMethodName = nameof(ContactApiController.Contact) + ". ";

        private Mock<IContactService> contactServiceMock;

        private ContactApiController contactApiController;

        [SetUp]
        public void TestInitialize()
        {
            contactServiceMock = MockRepository.Create<IContactService>();
            contactApiController = new ContactApiController(contactServiceMock.Object);
        }

        [TestCase(TestName = ContactMethodName + "Should return status OK")]
        public async Task ContactTest()
        {
            EmailData emailData = CreateEmailData();

            SetupContactServiceContactMock(emailData);
            OkResult expected = new OkResult();

            var actual = await contactApiController.Contact(emailData) as OkResult;

            Assert.AreEqual(expected.StatusCode, actual.StatusCode);
        }

        private void SetupContactServiceContactMock(EmailData emailData)
               => contactServiceMock
                   .Setup(service => service.ContactManagerAsync(emailData)).Returns(Task.CompletedTask);

        private EmailData CreateEmailData()
            => new EmailData();
    }
}