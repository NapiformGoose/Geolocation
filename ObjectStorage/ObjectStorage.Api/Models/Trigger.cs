using ObjectStorage.Api.Enums;

namespace ObjectStorage.Api.Models
{
    public class Trigger
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Marker> InitiatingMarkers { get; set; }

        public TriggerType Type { get; set; }

        public List<Action> Actions { get; set; }

        public bool Recurring { get; set; }

        public bool Active { get; set; }
    }
}
