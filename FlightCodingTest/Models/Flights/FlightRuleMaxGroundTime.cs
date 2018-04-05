using System;
using System.Linq;

namespace FlightCodingTest.Models.Flights
{
    public class FlightRuleMaxGroundTime : IFlightRule
    {
        private readonly TimeSpan _maxGroundTime;

        public FlightRuleMaxGroundTime(TimeSpan maxGroundTime)
        {
            _maxGroundTime = maxGroundTime;
        }

        public bool IsValid(Flight flight)
        {
            if (flight.Segments.Count() == 1) return true;

            var totalSegmentGap = new TimeSpan();

            for (var index = 0; index < (flight.Segments.Count() - 1); index++)
            {
                var segmentGap = flight.Segments[index + 1].DepartureDate - flight.Segments[index].ArrivalDate;
                totalSegmentGap += segmentGap;
            }

            if (totalSegmentGap > _maxGroundTime) return false;

            return true;
        }
    }
}
