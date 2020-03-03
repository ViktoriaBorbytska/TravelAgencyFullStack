using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgency.Interfaces.Services.Pipeline.Interfaces
{
    public interface IFilter<T>
    {
        T Execute(T input);
    }
}
