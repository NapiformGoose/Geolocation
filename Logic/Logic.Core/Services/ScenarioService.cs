using Geolocation.Logic.Api.Models;
using Geolocation.Logic.Api.Services;
using Geolocation.ObjectStorage.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Logic.Core.Services
{
    public class ScenarioService : IScenarioService
    {
        private readonly IScenarioObjectStorage _scenarioObjectStorage;

        public ScenarioService(IScenarioObjectStorage scenarioObjectStorage)
        {
            _scenarioObjectStorage = scenarioObjectStorage;
        }

        public Scenario Get(string scenarioId)
        {
            return _scenarioObjectStorage.Get(scenarioId);
        }

        public string Create(Scenario scenario)
        {
            return _scenarioObjectStorage.Add(scenario);
        }

        public string Delete(string scenarioId)
        {
            return _scenarioObjectStorage.Delete(scenarioId);
        }

        public Scenario Edit(Scenario scenario)
        {
            return _scenarioObjectStorage.Edit(scenario);
        }

        public List<Scenario> List()
        {
            return _scenarioObjectStorage.List();
        }
    }
}
