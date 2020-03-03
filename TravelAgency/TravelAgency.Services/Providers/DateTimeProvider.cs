using System;
using TravelAgency.Services.Interfaces.Providers;

namespace TravelAgency.Services.Providers
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}