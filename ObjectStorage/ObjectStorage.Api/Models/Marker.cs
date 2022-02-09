using Geolocation.ObjectStorage.Api.Enums;

namespace Geolocation.ObjectStorage.Api.Models
{
    public class Marker
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Position Position { get; set; }

        public Size Size { get; set; }

        public List<Position> Path { get; set; }

        public string Color { get; set; }

        public ShapeType Shape { get; set; }
    }
}
