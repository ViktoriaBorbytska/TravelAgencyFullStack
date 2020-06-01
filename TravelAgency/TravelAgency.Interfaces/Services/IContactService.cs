using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.Services
{
    public interface IContactService
    {
        Task ContactManagerAsync(EmailData emailData);
    }
}
