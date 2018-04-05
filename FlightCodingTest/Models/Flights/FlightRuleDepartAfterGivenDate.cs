using System;
using System.Linq;

namespace FlightCodingTest.Models.Flights
{
    public class FlightRuleDepartAfterGivenDate : IFlightRule
    {
        private readonly DateTime _departAfterDate;

        public FlightRuleDepartAfterGivenDate(DateTime departAfterDate)
        {
            _departAfterDate = departAfterDate;
        }

        public bool IsValid(Flight flight) => flight.Segments.First().DepartureDate > _departAfterDate;
    }
}
