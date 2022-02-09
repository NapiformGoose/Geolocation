using Geolocation.ObjectStorage.Api.Enums;

namespace Geolocation.ObjectStorage.Api.Models
{
    public class MapObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Marker Marker { get; set; }

        public List<Team> VisibleTo { get; set; }

        public bool Active { get; set; }

        public MapObjectType Type { get; set; }
    }
}
