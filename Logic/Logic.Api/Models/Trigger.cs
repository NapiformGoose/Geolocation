using Geolocation.Logic.Api.Enums;

namespace Geolocation.Logic.Api.Models
{
    public class Trigger
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<string> InitiatingMapObjectIds { get; set; }

        public TriggerType Type { get; set; }

        public List<Action> Actions { get; set; }

        public bool Recurring { get; set; }

        public bool Active { get; set; }
    }
}
