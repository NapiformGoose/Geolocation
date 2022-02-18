using Geolocation.Logic.Api.Models;
using Geolocation.Logic.Api.Services;
using Geolocation.ObjectStorage.Api.Services;

namespace Geolocation.Logic.Core.Services
{
    public class ScenarioService : IScenarioService
    {
        private readonly IRepository<Scenario> _scenarioRepository;

        public ScenarioService(IDataService dataService)
        {
            _scenarioRepository = dataService.Scenarios;
        }

        public Scenario Get(string scenarioId)
        {
            return _scenarioRepository.Get(scenarioId);
        }

        public string Create(Scenario scenario)
        {
            return _scenarioRepository.Create(scenario);
        }

        public string Delete(string scenarioId)
        {
            return _scenarioRepository.Delete(scenarioId);
        }

        public Scenario Edit(Scenario scenario)
        {
            return _scenarioRepository.Edit(scenario);
        }

        public List<Scenario> List()
        {
            return _scenarioRepository.GetAll().ToList();
        }
    }
}
