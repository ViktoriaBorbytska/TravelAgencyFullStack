//using System.Threading.Tasks;
//using TravelAgency.Services;
//using Moq;
//using NUnit.Framework;
//using TravelAgency.Services.Interfaces.Handlers;
//using TravelAgency.Interfaces.Dto;
//
//namespace TravelAgency.Tests.Service
//{
//    [TestFixture]
//    internal class ContactServiceTest : UnitTestBase
//    {
//        private const string ContactManagerAsyncMethodName = nameof(ContactService.ContactManagerAsync) + ". ";
//        private const string recieverEmail = "manager@gmail.com";
//
//        private Mock<IMailHandler> mailHandlerMock;
//
//        private ContactService contactService;
//
//        [SetUp]
//        public void TestInitialize()
//        {
//            mailHandlerMock = MockRepository.Create<IMailHandler>();
//            contactService = new ContactService(mailHandlerMock.Object);
//        }
//
//        [TestCase(TestName = ContactManagerAsyncMethodName + "Should send a mail")]
//        public async Task ContactManagerAsyncTest()
//        {
//            EmailData emailData = CreateEmailData();
//
//            await contactService.ContactManagerAsync(emailData);
//        }
//
//        private void SetupMailHandlerSendMailAsyncMock(EmailData emailData, string reciever)
//            => mailHandlerMock
//                .Setup(handler => handler.SendMailAsync(emailData, reciever));
//
//        private EmailData CreateEmailData() => new EmailData();
//    }
//}