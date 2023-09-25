using Common.Types;

namespace Common.Services
{
    public class JsonProcessFlightsService : IProcessService<List<FlightInfo>>
    {
        public List<FlightInfo> Value { get; set; }

        public event Action OnFileLoaded;

        public List<FlightInfo> Load(string path)
        {
            throw new NotImplementedException();
        }

        public void Save(List<FlightInfo> entity, string path)
        {
            throw new NotImplementedException();
        }

        public JsonProcessFlightsService()
        {

        }
    }
}
