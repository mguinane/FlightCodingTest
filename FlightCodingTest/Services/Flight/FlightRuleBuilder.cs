using FlightCodingTest.Models.Flights;
using System;
using System.Collections.Generic;

namespace FlightCodingTest.Services.Flights
{
    public class FlightRuleBuilder
    {
        public FlightRuleBuilder() { }

        public IList<IFlightRule> GetRules()
        {
            return new List<IFlightRule>
            {
                new FlightRuleDepartAfterGivenDate(DateTime.Now),
                new FlightRuleDepartBeforeArrival(),
                new FlightRuleMaxGroundTime(TimeSpan.FromHours(2))
            };
        }
    }
}
