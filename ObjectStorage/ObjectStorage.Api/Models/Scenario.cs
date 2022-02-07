namespace ObjectStorage.Api.Models
{
    public class Scenario
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Task> Tasks { get; set; }

        public List<MapObject> MapObjects { get; set; }

    }
}
