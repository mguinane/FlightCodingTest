using FlightCodingTest.Models.Flights;
using System.Collections.Generic;

namespace FlightCodingTest.Services.Flights
{
    public class FlightFilter
    {
        public FlightFilter() { }

        public bool ApplyRules(Flight flight, IList<IFlightRule> flightRules)
        {
            foreach (var flightRule in flightRules)
                if (!flightRule.IsValid(flight)) return false;

            return true;
        }
    }
}
