using FlightCodingTest.Services.Flights;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FlightCodingTest.Controllers
{
    [Produces("application/json")]
    [Route("api/flights")]
    public class FlightsController : Controller
    {
        private readonly FlightBuilder _flightBuilder;
        private readonly FlightRuleBuilder _flightRuleBuilder;
        private readonly FlightFilter _flightFilter;

        public FlightsController(FlightBuilder flightbuilder, FlightRuleBuilder flightRuleBuilder, FlightFilter flightFilter)
        {
            // TODO tightly coupled to implementation - create generic interfaces for content builder / rule builder / content filter

            _flightBuilder = flightbuilder;
            _flightRuleBuilder = flightRuleBuilder;
            _flightFilter = flightFilter;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var flightRules = _flightRuleBuilder.GetRules();

            var flightResults = _flightBuilder
                .GetFlights()
                .Where(flight => _flightFilter.ApplyRules(flight, flightRules));

            return Ok(flightResults.ToList());
        }
    }
}
