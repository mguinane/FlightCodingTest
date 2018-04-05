using FlightCodingTest.Models.Flights;
using System;
using System.Linq;

namespace FlightCodingTest.Tests.Models.Flights
{
    public class FlightHelper
    {
        // TODO - DRY violation with FlightBuilder.cs ...

        public static Flight CreateFlight(params DateTime[] dates)
        {
            if (dates.Length % 2 != 0)
                throw new ArgumentException("You must pass an even number of dates,", "dates");

            var departureDates = dates.Where((date, index) => index % 2 == 0);
            var arrivalDates = dates.Where((date, index) => index % 2 == 1);

            var segments = departureDates
                .Zip(arrivalDates, (departureDate, arrivalDate) => new Segment { DepartureDate = departureDate, ArrivalDate = arrivalDate })
                .ToList();

            return new Flight { Segments = segments };
        }
    }
}
