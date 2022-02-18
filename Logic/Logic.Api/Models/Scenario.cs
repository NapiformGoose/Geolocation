using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Geolocation.Logic.Api.Models
{
    public class Scenario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public List<ScenarioTask> Tasks { get; set; }

        public List<MapObject> MapObjects { get; set; }

        public List<Trigger> Triggers { get; set; }

        //GlobalActions
    }
}
