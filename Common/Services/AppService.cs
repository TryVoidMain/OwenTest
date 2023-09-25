using Common.Types;

namespace Common.Services
{
    public class AppService : IAppService
    {
        public List<FlightInfo> Flights { get; set; }
        public List<FlightInfo> GetFlights()
        {
            throw new NotImplementedException();
        }
        public void SaveFlights(List<FlightInfo> flights)
        {
            throw new NotImplementedException();
        }
    }
}
