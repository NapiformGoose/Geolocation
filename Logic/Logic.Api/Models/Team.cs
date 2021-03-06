namespace Geolocation.Logic.Api.Models
{
    public class Team
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Team> Allies { get; set; }

        public List<Team> Enemies { get; set; }

        public List<Team> Neutrals { get; set; }
    }
}
