using Geolocation.Logic.Api.Enums;

namespace Geolocation.Logic.Api.Models
{
    public abstract class Action
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public abstract ActionType Type { get; }

        public List<string> Targets { get; set; } //Tasks, MapObjects and Triggers
    }

    public class ChangeColorAction : Action
    {
        public override ActionType Type => ActionType.ChangeColor;

        public string NewColor { get; set; }
    }
}
