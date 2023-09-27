using Common.Types;

namespace Common.Services
{
    public interface IFlightsService : ILoadService<List<FlightInfo>>, ISaveService<List<FlightInfo>> 
    {
        List<FlightInfo> GetDefault();

        public event Action OnFileLoaded;
    }
}
