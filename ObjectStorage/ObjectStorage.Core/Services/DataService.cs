using Geolocation.Logic.Api.Models;
using Geolocation.ObjectStorage.Api.Services;
using Geolocation.ObjectStorage.Core.Repositories;

namespace Geolocation.ObjectStorage.Core.Services
{
    public class DataService : IDataService
    {
        private readonly DbContext _dbContext;

        public IRepository<User> Users => new UserRepository(_dbContext.Database);

        public IRepository<Scenario> Scenarios => new ScenarioRepository(_dbContext.Database);

        public DataService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
