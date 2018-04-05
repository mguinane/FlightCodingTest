using FlightCodingTest.Models.Flights;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FlightCodingTest.Tests.Models.Flights
{
    public class FlightRuleMaxGroundTimeTests
    {
        public FlightRuleMaxGroundTimeTests() { }

        [Fact]
        public void IsValid_FlightWithTwoSegmentsGroundTimeNotExceedsMax_ReturnTrue()
        {
            //Arrange
            var maxGroundTime = TimeSpan.FromHours(2);
            var flight = FlightHelper.CreateFlight(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(2),
                DateTime.Now.AddDays(3).AddHours(3), DateTime.Now.AddDays(4));
            var flightRule = new FlightRuleMaxGroundTime(maxGroundTime);

            //Act
            var result = flightRule.IsValid(flight);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_FlightWithTwoSegmentsGroundTimeExceedsMax_ReturnFalse()
        {
            //Arrange
            var maxGroundTime = TimeSpan.FromHours(2);
            var flight = FlightHelper.CreateFlight(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(2),
                DateTime.Now.AddDays(3).AddHours(5), DateTime.Now.AddDays(4));
            var flightRule = new FlightRuleMaxGroundTime(maxGroundTime);

            //Act
            var result = flightRule.IsValid(flight);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_FlightWithThreeSegmentsGroundTimeNotExceedsMax_ReturnTrue()
        {
            //Arrange
            var maxGroundTime = TimeSpan.FromHours(4);
            var flight = FlightHelper.CreateFlight(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(2),
                DateTime.Now.AddDays(3).AddHours(4), DateTime.Now.AddDays(4),
                DateTime.Now.AddDays(4).AddHours(1), DateTime.Now.AddDays(5));
            var flightRule = new FlightRuleMaxGroundTime(maxGroundTime);

            //Act
            var result = flightRule.IsValid(flight);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_FlightWithThreeSegmentsGroundTimeExceedsMax_ReturnFalse()
        {
            //Arrange
            var maxGroundTime = TimeSpan.FromHours(4);
            var flight = FlightHelper.CreateFlight(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(2),
                DateTime.Now.AddDays(3).AddHours(4), DateTime.Now.AddDays(4),
                DateTime.Now.AddDays(4).AddHours(4), DateTime.Now.AddDays(5));
            var flightRule = new FlightRuleMaxGroundTime(maxGroundTime);

            //Act
            var result = flightRule.IsValid(flight);

            //Assert
            result.Should().BeFalse();
        }
    }
}
