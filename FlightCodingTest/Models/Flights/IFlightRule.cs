namespace FlightCodingTest.Models.Flights
{
    public interface IFlightRule
    {
        bool IsValid(Flight flight);
    }
}
