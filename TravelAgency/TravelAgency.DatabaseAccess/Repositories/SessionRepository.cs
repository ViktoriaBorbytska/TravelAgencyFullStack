using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.DatabaseAccess.Repositories
{
    internal class SessionRepository : ISessionRepository
    {
        private readonly ITravelAgencyDbContext context;

        public SessionRepository(ITravelAgencyDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(SessionData sessionData)
        {
            var session = new Session
            {
                UserId = sessionData.UserId,
                Token = sessionData.Token
            };

            await context.Sessions.AddAsync(session);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(SessionData sessionData)
        {
            Session session = await context.Sessions.FirstOrDefaultAsync(record =>
                record.Token == sessionData.Token);

            context.Sessions.Remove(session);
            await context.SaveChangesAsync();
        }

        public async Task<SessionData> GetByTokenAsync(string token)
            => Map(await context.Sessions.FirstOrDefaultAsync(session => session.Token == token));

        private SessionData Map(Session session)
            => (session == null) ? null : new SessionData
            {
                Id = session.Id,
                Token = session.Token,
                UserId = session.UserId,
            };

        private Session Map(SessionData sessionData)
            => new Session
            {
                Token = sessionData.Token,
                UserId = sessionData.UserId,
            };
    }
}