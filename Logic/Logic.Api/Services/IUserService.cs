using Geolocation.Logic.Api.Models;

namespace Geolocation.Logic.Api.Services
{
    public interface IUserService
    {
        User Get(string userId);

        string Create(User user);

        User Edit(User user);

        string Delete(string userId);

        List<User> List();
    }
}
