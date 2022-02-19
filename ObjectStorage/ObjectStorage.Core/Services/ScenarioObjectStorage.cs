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
        private Scenario _runningScenario;


        public ScenarioObjectStorage()
        {
        }

        public void AddRunningScenario(Scenario scenario)
        {
            _runningScenario = scenario;
        }

        public void ClearStorage()
        {
            _runningScenario = null;
        }

        public MapObject GetMapObject(string mapObjectId)
        {
            return _runningScenario.MapObjects.Where(mo => mo.Id.Equals(mapObjectId)).FirstOrDefault();
        }

        public List<Trigger> GetMapObjectTriggers(string mapObjectId)
        {
            return _runningScenario.Triggers.Where(trigger => trigger.Initiators.Contains(mapObjectId)).ToList(); //todo инициаторы или ещё и таргеты?
        }

        public Dictionary<string, Trigger> GetTriggers()
        {
            return _runningScenario.Triggers.ToDictionary(trigger => trigger.Id);
        }

        public Dictionary<string, MapObject> GetMapObjects()
        {
            return _runningScenario.MapObjects.ToDictionary(mo => mo.Id);
        }
    }
}
