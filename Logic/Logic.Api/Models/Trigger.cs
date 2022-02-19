using Geolocation.Logic.Api.Enums;

namespace Geolocation.Logic.Api.Models
{
    public abstract class Trigger
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<string> Targets { get; set; }

        public List<string> Initiators { get; set; }

        public abstract TriggerType Type { get; }

        public List<Action> Actions { get; set; }

        public bool Recurring { get; set; }

        public bool Active { get; set; }
    }

    public class AttendTrigger : Trigger
    {
        public override TriggerType Type => TriggerType.Attend;
    }
}
