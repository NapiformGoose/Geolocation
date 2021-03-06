using Geolocation.Logic.Api.Enums;

namespace Geolocation.Logic.Api.Models
{
    public class MapObject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Marker Marker { get; set; }

        public List<Team> VisibleTo { get; set; }

        public bool Active { get; set; }

        public MapObjectType Type { get; set; }
    }
}
