using Geolocation.Logic.Api.Models;

namespace Geolocation.ObjectStorage.Api.Services
{
    public interface IDataService
    {
        IRepository<User> Users { get; }

        IRepository<Scenario> Scenarios { get; }
    }
}
