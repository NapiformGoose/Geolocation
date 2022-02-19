using Geolocation.Logic.Api;
using Geolocation.Logic.Api.Enums;
using Geolocation.Logic.Api.Models;
using Geolocation.Logic.Api.Services;
using Geolocation.ObjectStorage.Api.Services;

namespace Geolocation.Logic.Core.Services
{
    public class ScenarioManager : IScenarioManager, IObserver
    {
        private readonly IScenarioService _scenarioService;

        private readonly IScenarioObjectStorage _scenarioObjectStorage;

        private readonly ITriggerInitiator _triggerInitiator;

        private readonly IActionInitiator _actionInitiator;

        private List<MapObject> _updatedMapObjects;

        public ScenarioManager(IScenarioService scenarioService, IScenarioObjectStorage scenarioObjectStorage, ITriggerInitiator triggerInitiator, IActionInitiator actionInitiator)
        {
            _scenarioService = scenarioService;
            _scenarioObjectStorage = scenarioObjectStorage;
            _triggerInitiator = triggerInitiator;
            _actionInitiator = actionInitiator;

            _updatedMapObjects = new List<MapObject>();

            _triggerInitiator.RegisterObserver(this);
            _actionInitiator.RegisterObserver(this);
        }

        public void AddUpdatedMapObjects(List<MapObject> mapObjects)
        {
            _updatedMapObjects.AddRange(mapObjects);
        }

        public List<MapObject> GetUpdatedMapObjects()
        {
            return _updatedMapObjects;
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
            _triggerInitiator.Initiate();
        }
    }
}
