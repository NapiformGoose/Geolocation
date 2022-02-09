using Geolocation.Logic.Api.Models;
using Geolocation.ObjectStorage.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.ObjectStorage.Core.Services
{
    public class ScenarioObjectStorage : IScenarioObjectStorage
    {
        private Dictionary<string, Scenario> _scenarios { get; }

        public ScenarioObjectStorage()
        {
            _scenarios = new Dictionary<string, Scenario>();
        }

        public Scenario Get(string scenarioId)
        {
            if (_scenarios.TryGetValue(scenarioId, out var scenario))
            {
                return scenario;
            }
            return null;
        }

        public string Add(Scenario scenario)
        {
            var id = Guid.NewGuid().ToString();
            return _scenarios.TryAdd(id, scenario) ? id : null;
        }

        public Scenario Edit(Scenario scenario)
        {
            if (_scenarios.TryGetValue(scenario.Id, out var oldScenario))
            {
                oldScenario = scenario;
            }
            return oldScenario;
        }

        public string Delete(string scenarioId)
        {
            _scenarios.Remove(scenarioId);
            return scenarioId;
        }

        public List<Scenario> List()
        {
            var list = new List<Scenario>(_scenarios.Count);
            foreach (var scenario in _scenarios)
            {
                list.Add(scenario.Value);
            }

            return list;
        }
    }
}
