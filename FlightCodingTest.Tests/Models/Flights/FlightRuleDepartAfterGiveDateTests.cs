using FlightCodingTest.Models.Flights;
using FluentAssertions;
using System;
using Xunit;

namespace FlightCodingTest.Tests.Models.Flights
{
    public class FlightRuleDepartAfterGivenDateTests
    {
        public FlightRuleDepartAfterGivenDateTests() { }

        [Fact]
        public void IsValid_FlightDepartsAfterGivenDate_ReturnTrue()
        {
            //Arrange
            var givenDate = DateTime.Now;
            var flight = FlightHelper.CreateFlight(givenDate.AddDays(3), givenDate.AddDays(3).AddHours(2));
            var flightRule = new FlightRuleDepartAfterGivenDate(givenDate);

            //Act
            var result = flightRule.IsValid(flight);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_FlightDepartsBeforeGivenDate_ReturnFalse()
        {
            //Arrange
            var givenDate = DateTime.Now;
            var flight = FlightHelper.CreateFlight(givenDate.AddDays(-3), givenDate.AddDays(-3).AddHours(2));
            var flightRule = new FlightRuleDepartAfterGivenDate(givenDate);

            //Act
            var result = flightRule.IsValid(flight);

            //Assert
            result.Should().BeFalse();
        }
    }
}
