using System.Collections.Generic;
using TravelAgency.Interfaces.Services.Pipeline.Interfaces;

namespace TravelAgency.Interfaces.Services.Pipeline.AbstractClasses
{
    public abstract class Pipeline<T>
    {
        protected readonly List<IFilter<T>> filters;

        public Pipeline()
        {
            filters = new List<IFilter<T>>();
        }

        public Pipeline<T> Register(IFilter<T> filter)
        {
            filters.Add(filter);
            return this;
        }

        public abstract T Process(T input);
    }
}
