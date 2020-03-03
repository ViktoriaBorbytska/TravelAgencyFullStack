namespace TravelAgency.Services.Interfaces.Factories
{
    public interface IJavascriptWebTokenFactory
    {
        string Create(int userId);
    }
}