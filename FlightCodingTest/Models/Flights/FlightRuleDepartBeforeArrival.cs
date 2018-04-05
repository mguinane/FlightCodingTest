using System.Linq;

namespace FlightCodingTest.Models.Flights
{
    public class FlightRuleDepartBeforeArrival : IFlightRule
    {
        public FlightRuleDepartBeforeArrival() { }

        public bool IsValid(Flight flight) => !flight.Segments.Any(s => s.ArrivalDate < s.DepartureDate);
    }
}
