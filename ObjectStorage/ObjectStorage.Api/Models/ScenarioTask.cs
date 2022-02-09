using Geolocation.ObjectStorage.Api.Enums;

namespace Geolocation.ObjectStorage.Api.Models
{
    public class ScenarioTask
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ScenarioTaskStatus Status { get; set; }

        public ScenarioTask(int id, string name, ScenarioTaskStatus status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }
}
