using Geolocation.Logic.Api;
using Geolocation.Logic.Api.Enums;
using Geolocation.Logic.Api.Models;
using Geolocation.Logic.Api.Services;
using Geolocation.ObjectStorage.Api.Services;

namespace Geolocation.Logic.Core.Services
{
    public class TriggerInitiator : ITriggerInitiator
    {
        private readonly IScenarioObjectStorage _scenarioObjectStorage;

        private readonly IActionInitiator _actionInitiator;

        private List<IObserver> _observers;

        public TriggerInitiator(IScenarioObjectStorage scenarioObjectStorage, IActionInitiator actionInitiator)
        {
            _scenarioObjectStorage = scenarioObjectStorage;
            _actionInitiator = actionInitiator;
            _observers = new List<IObserver>();
        }

        public void Initiate()
        {
            var triggers = _scenarioObjectStorage.GetTriggers(); //todo или лучше прокинуть

            foreach (var trigger in triggers.Values)
            {
                switch (trigger)
                {
                    case AttendTrigger attendTrigger:
                        InitAttendTrigger(attendTrigger);
                        break;

                    default:
                        throw new ArgumentException();
                }
            }
        }

        private void InitAttendTrigger(AttendTrigger trigger)
        {
            var targets = new List<MapObject>();
            var initiators = new List<MapObject>();
            SetTargetsAndInitiators(trigger, targets, initiators);

            foreach (var target in targets)
            {
                foreach (var initiator in initiators)
                {
                    var distance = GetDistance(target.Position, initiator.Position);
                    if (distance <= target.Size.Radius)
                    {
                        _actionInitiator.Initiate(trigger.Actions);
                    }
                }
            }
        }

        private void SetTargetsAndInitiators(Trigger trigger, List<MapObject> targets, List<MapObject> initiators)
        {
            var mapObjects = _scenarioObjectStorage.GetMapObjects();

            foreach (var target in trigger.Targets)
            {
                if (mapObjects.TryGetValue(target, out var mapObject))
                {
                    targets.Add(mapObject);
                }
            }

            foreach (var initiator in trigger.Initiators)
            {
                if (mapObjects.TryGetValue(initiator, out var mapObject))
                {
                    initiators.Add(mapObject);
                }
            }
        }

        private double GetDistance(Position position1, Position position2)
        {
            const double EarthRadius = 6371; // meters

            var sdlat = Math.Sin((position2.Latitude - position1.Latitude) / 2);
            var sdlon = Math.Sin((position2.Longitude - position1.Longitude) / 2);
            var q = sdlat * sdlat + Math.Cos(position1.Latitude) * Math.Cos(position2.Latitude) * sdlon * sdlon;
            var distance = 2 * EarthRadius * Math.Asin(Math.Sqrt(q));

            return distance;
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);

        }

        public void NotifyObservers(List<MapObject> mapObjects)
        {
            foreach (var observer in _observers)
            {
                observer.AddUpdatedMapObjects(null);
            }
        }
    }
}
