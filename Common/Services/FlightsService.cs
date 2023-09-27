using Common.Infrastructure;
using Common.Types;
using System.Text.Json;

namespace Common.Services
{
    public class FlightsService : IFlightsService
    {
        public event Action OnFileLoaded;

        public List<FlightInfo> Load(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var fileContent = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<List<FlightInfo>>(fileContent);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Unable to load {filePath}.\nError message: {ex.Message}");
            }

            return new List<FlightInfo>();
        }

        public void Save(List<FlightInfo> entity, string filePath)
        {
            try
            {
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var json = JsonSerializer.Serialize(entity);

                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Logger.Error($"Unable to save {filePath}.\nError message: {ex.Message}");
            }
        }

        public List<FlightInfo> GetDefault()
        {
            return new List<FlightInfo> {
                new FlightInfo()
                {
                    DepartureTime = DateTime.Now,
                    FlightNumber = "Flight number",
                    Passengers = new List<Passenger>()
                    {
                        new("Ivan", "Ivanov", "Ivanovich")
                    }
                }
            };
        }

        public FlightsService()
        {

        }
    }
}
