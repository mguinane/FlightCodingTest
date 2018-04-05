using System.Collections.Generic;

namespace FlightCodingTest.Models.Flights
{
    public class Flight
    {
        public IList<Segment> Segments { get; set; }
    }
}
