using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using TravelAgency.Services.Interfaces.Factories;

namespace TravelAgency.Services.Factories
{
    internal class JavascriptWebTokenFactory : IJavascriptWebTokenFactory
    {
        private readonly ISecurityTokenDescriptorFactory securityTokenDescriptorFactory;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;

        public JavascriptWebTokenFactory(ISecurityTokenDescriptorFactory securityTokenDescriptorFactory, JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            this.securityTokenDescriptorFactory = securityTokenDescriptorFactory;
            this.jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }

        public string Create(int userId)
        {
            SecurityTokenDescriptor tokenDescriptor = securityTokenDescriptorFactory.Create(userId);
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}