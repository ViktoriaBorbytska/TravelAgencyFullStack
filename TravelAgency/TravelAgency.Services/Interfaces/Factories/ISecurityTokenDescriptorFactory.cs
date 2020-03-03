using Microsoft.IdentityModel.Tokens;

namespace TravelAgency.Services.Interfaces.Factories
{
    internal interface ISecurityTokenDescriptorFactory
    {
        SecurityTokenDescriptor Create(int userId);
    }
}