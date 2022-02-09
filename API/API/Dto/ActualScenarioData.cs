using Geolocation.ObjectStorage.Api.Models;
using ScenarioTask = Geolocation.ObjectStorage.Api.Models.ScenarioTask;

namespace Geolocation.API.Dto
{
    public class ActualScenarioData
    {
        public List<MapObject> MapObjects { get; set; }

        public List<ScenarioTask> Tasks { get; set; }
    }
}
