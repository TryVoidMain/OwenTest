using Common.Types;

namespace Common.Services
{
    public interface IAppService
    {
        List<FlightInfo> Flights { get; set; }
        List<FlightInfo> GetFlights();
        void SaveFlights(List<FlightInfo> flights);
    }
}
