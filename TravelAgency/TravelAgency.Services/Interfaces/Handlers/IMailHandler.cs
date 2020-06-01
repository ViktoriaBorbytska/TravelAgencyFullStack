using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Services.Interfaces.Handlers
{
    public interface IMailHandler
    {
        Task SendMailAsync(EmailData emailData, string receiverAddress);
    }
}
