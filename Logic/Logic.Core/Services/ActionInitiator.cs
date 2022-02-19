using Geolocation.Logic.Api;
using Geolocation.Logic.Api.Models;
using Geolocation.Logic.Api.Services;
using Geolocation.ObjectStorage.Api.Services;

using Action = Geolocation.Logic.Api.Models.Action;

namespace Geolocation.Logic.Core.Services
{
    public class ActionInitiator : IActionInitiator
    {
        private readonly IScenarioObjectStorage _scenarioObjectStorage;

        private List<IObserver> _observers;

        public ActionInitiator(IScenarioObjectStorage scenarioObjectStorage)
        {
            _scenarioObjectStorage = scenarioObjectStorage;
            _observers = new List<IObserver>();
        }

        public void Initiate(List<Action> actions)
        {
            foreach (var action in actions)
            {
                switch (action)
                {
                    case ChangeColorAction changeColorAction:
                        InitiateChangeColorAction(changeColorAction);
                        break;

                    default:
                        throw new ArgumentException();
                }
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(List<MapObject> objects)
        {
            foreach (var observer in _observers)
            {
                observer.AddUpdatedMapObjects(objects);
            }
        }

        private void InitiateChangeColorAction(ChangeColorAction action)
        {
            var updatedMapObjects = new List<MapObject>();

            var targets = new List<MapObject>();
            foreach (var targetId in action.Targets)
            {
                var targetMapObject = _scenarioObjectStorage.GetMapObject(targetId);
                if (targetMapObject != null)
                {
                    targets.Add(targetMapObject);
                }
            }
            foreach (var target in targets)
            {
                target.Marker.Color = action.NewColor;
                updatedMapObjects.Add(target);
            }

            NotifyObservers(updatedMapObjects);
        }
    }
}
