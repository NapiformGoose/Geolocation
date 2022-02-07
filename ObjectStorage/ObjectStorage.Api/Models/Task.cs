namespace ObjectStorage.Api.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TaskStatus Status { get; set; }
    }
}
