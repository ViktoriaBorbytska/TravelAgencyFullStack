using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.Interfaces.Services.Pipeline.AbstractClasses;

namespace TravelAgency.DatabaseAccess.Pipeline
{
    internal class OfferSelectionPipeline : Pipeline<IQueryable<Offer>>
    {
        public override IQueryable<Offer> Process(IQueryable<Offer> input)
        {
            foreach(var filter in filters)
            {
                input = filter.Execute(input);
            }

            return input;
        }
    }
}
