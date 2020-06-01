using System;

namespace TravelAgency.Services.Interfaces.Providers
{
    internal interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}