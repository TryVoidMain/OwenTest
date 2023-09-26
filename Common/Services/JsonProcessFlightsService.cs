using Common.Types;
using System.Text.Json;

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
            var json = JsonSerializer.Serialize(entity);

            using (var output = new StreamWriter(Path.Combine(Environment.CurrentDirectory, path)))
            {
                output.WriteLine(json);
            }
        }

        public JsonProcessFlightsService()
        {

        }
    }
}
