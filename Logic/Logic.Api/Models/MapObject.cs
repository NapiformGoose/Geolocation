using Geolocation.Logic.Api.Enums;

namespace Geolocation.Logic.Api.Models
{
    public class MapObject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Position Position { get; set; }

        public Size Size { get; set; }

        public string Icon { get; set; }

        public List<Position> Path { get; set; }

        public string Color { get; set; }

        public List<Team> VisibleTo { get; set; }

        public bool Active { get; set; }

        public MapObjectType Type { get; set; }

        public User User { get; set; }

        public Team Team { get; set; }
    }
}
