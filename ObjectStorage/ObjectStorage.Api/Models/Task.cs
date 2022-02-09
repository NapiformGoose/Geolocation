using Geolocation.ObjectStorage.Api.Enums;

namespace ObjectStorage.Api.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ScenarioTaskStatus Status { get; set; }
    }
}
