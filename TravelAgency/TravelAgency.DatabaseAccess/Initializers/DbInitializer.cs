using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.Interfaces.DatabaseAccess.Initializers;

namespace TravelAgency.DatabaseAccess.Initializers
{
    internal class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ITravelAgencyDbContext context;

        public DatabaseInitializer(ITravelAgencyDbContext context)
        {
            this.context = context;
        }

        public void Initialize()
        {
            context.Database.EnsureCreated();
        }
    }
}
