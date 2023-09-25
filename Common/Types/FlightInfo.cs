namespace Common.Types
{
    public class FlightInfo
    {
        public DateTime DepartureTime { get; set; }
        public string FlightNumber { get; set; }
        public List<Passenger> Passengers { get; set; }

        public FlightInfo(DateTime departureTime, string flightNumber, List<Passenger> passengers)
        {
            DepartureTime = departureTime;
            FlightNumber = flightNumber;
            Passengers = passengers;
        }
    }
}
