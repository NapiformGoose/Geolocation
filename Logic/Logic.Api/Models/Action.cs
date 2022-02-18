using Geolocation.Logic.Api.Enums;

namespace Geolocation.Logic.Api.Models
{
    public class Action
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ActionType Type { get; set; }

        public List<string> Targets { get; set; } //Tasks, MapObjects and Triggers
    }
}
