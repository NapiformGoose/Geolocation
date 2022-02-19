using Geolocation.Logic.Api.Models;

namespace Geolocation.Logic.Api
{
    public interface IObservable
    {
        void RegisterObserver(IObserver observer);

        void RemoveObserver(IObserver observer);

        void NotifyObservers(List<MapObject> mapObjects);
    }
}
