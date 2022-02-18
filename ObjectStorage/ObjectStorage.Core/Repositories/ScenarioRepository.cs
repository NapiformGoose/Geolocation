using Geolocation.Logic.Api.Models;
using Geolocation.ObjectStorage.Api.Services;
using MongoDB.Driver;

namespace Geolocation.ObjectStorage.Core.Repositories
{
    public class ScenarioRepository : IRepository<Scenario>
    {
        private readonly IMongoCollection<Scenario> _scenarios;

        public ScenarioRepository(IMongoDatabase database)
        {
            _scenarios = database.GetCollection<Scenario>("Scenarios");
        }

        public string Create(Scenario scenario)
        {
            _scenarios.InsertOne(scenario);
            return scenario.Id;
        }

        public string Delete(string id)
        {
            _scenarios.DeleteOne(s => s.Id == id);
            return id;
        }

        public Scenario Edit(Scenario scenario)
        {
            var filter = Builders<Scenario>.Filter.Where(s => s.Id == scenario.Id);
            _scenarios.ReplaceOne(filter, scenario);
            return scenario; //todo протестировать изменение
        }

        public Scenario Get(string id)
        {
            var filter = Builders<Scenario>.Filter.Where(s => s.Id == id);
            return _scenarios.Find(filter).FirstOrDefault();
        }

        public IQueryable<Scenario> GetAll()
        {
            return _scenarios.AsQueryable();
        }
    }
}
