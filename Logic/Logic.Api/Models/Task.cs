using Geolocation.Logic.Api.Enums;

namespace Geolocation.Logic.Api.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ScenarioTaskStatus Status { get; set; }
    }
}
