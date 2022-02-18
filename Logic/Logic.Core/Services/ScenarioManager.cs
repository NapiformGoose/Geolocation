using Geolocation.Logic.Api.Enums;
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
    public class ScenarioManager : IScenarioManager
    {

        private readonly IScenarioService _scenarioService;
        private readonly IScenarioObjectStorage _scenarioObjectStorage;

        public ScenarioManager(IScenarioService scenarioService, IScenarioObjectStorage scenarioObjectStorage)
        {
            _scenarioService = scenarioService;
            _scenarioObjectStorage = scenarioObjectStorage;
        }

        public void RunScenario(string scenarioId)
        {
            var scenario = _scenarioService.Get(scenarioId);
            if (scenario == null)
            {
                throw new Exception("Сценарий не найден"); //todo localization
            }

            _scenarioObjectStorage.AddRunningScenario(scenario);
        }

        public void StopScenario()
        {
            _scenarioObjectStorage.ClearStorage();
        }

        public void UpdateMapObjectState(MapObject updatedMapObject)
        {
            var mapObject = _scenarioObjectStorage.GetMapObject(updatedMapObject.Id);
            mapObject.Marker.Position = updatedMapObject.Marker.Position;

            var triggers = _scenarioObjectStorage.GetMapObjectTriggers(updatedMapObject.Id);
        }

        private void CheckTrigger(List<Trigger> triggers)
        {
            foreach (var trigger in triggers)
            {
                if (trigger.Type == TriggerType.Attend)
                {

                }
            }
        }

        private void InitAttendTrigger(Trigger trigger)
        {
            foreach (var action in trigger.Actions)
            {
                if (action.Type == ActionType.ChangeColor)
                {

                }
            }
        }
    }
}
