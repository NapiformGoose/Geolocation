using Geolocation.Logic.Api.Enums;

namespace Geolocation.Logic.Api.Models
{
    public class ScenarioTask
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ScenarioTaskStatus Status { get; set; }

        public ScenarioTask(string id, string name, ScenarioTaskStatus status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }
}
