namespace Geolocation.Logic.Api.Models
{
    public class User
    {
        public string Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public bool Admin { get; set; }
    }
}
