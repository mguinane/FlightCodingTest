using FlightCodingTest.Models.Flights;
using FluentAssertions;
using System;
using Xunit;

namespace FlightCodingTest.Tests.Models.Flights
{
    public class FlightRuleDepartBeforeArrivalTests
    {
        public FlightRuleDepartBeforeArrivalTests() { }

        [Fact]
        public void IsValid_FlightWithSingleSegmentDepartsBeforeArrival_ReturnTrue()
        {
            //Arrange
            var flight = FlightHelper.CreateFlight(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(2));
            var flightRule = new FlightRuleDepartBeforeArrival();

            //Act
            var result = flightRule.IsValid(flight);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_FlightWithSingleSegmentDepartsAfterArrival_ReturnFalse()
        {
            //Arrange
            var flight = FlightHelper.CreateFlight(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(-2));
            var flightRule = new FlightRuleDepartBeforeArrival();

            //Act
            var result = flightRule.IsValid(flight);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_FlightWithMultipleSegmentsDepartsBeforeArrival_ReturnTrue()
        {
            //Arrange
            var flight = FlightHelper.CreateFlight(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(2), 
                DateTime.Now.AddDays(3).AddHours(5), DateTime.Now.AddDays(4));
            var flightRule = new FlightRuleDepartBeforeArrival();

            //Act
            var result = flightRule.IsValid(flight);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_FlightWithMultipleSegmentsDepartsAfterArrival_ReturnFalse()
        {
            //Arrange
            var flight = FlightHelper.CreateFlight(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(2),
                DateTime.Now.AddDays(4).AddHours(1), DateTime.Now.AddDays(4));
            var flightRule = new FlightRuleDepartBeforeArrival();

            //Act
            var result = flightRule.IsValid(flight);

            //Assert
            result.Should().BeFalse();
        }
    }
}