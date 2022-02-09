using Geolocation.Logic.Api.Models;

namespace Geolocation.API.Dto
{
    public class ActualScenarioData
    {
        public List<MapObject> MapObjects { get; set; }

        public List<ScenarioTask> Tasks { get; set; }
    }
}
