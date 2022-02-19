using Geolocation.Logic.Api.Models;

namespace Geolocation.Logic.Api
{
    public interface IObserver
    {
        public void AddUpdatedMapObjects(List<MapObject> mapObjects);
    }
}
