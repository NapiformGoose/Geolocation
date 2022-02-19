using Geolocation.Logic.Api.Models;

namespace Geolocation.ObjectStorage.Api.Services
{
    public interface IScenarioObjectStorage
    {
        void AddRunningScenario(Scenario scenario);

        void ClearStorage();

        MapObject GetMapObject(string mapObjectId);

        List<Trigger> GetMapObjectTriggers(string mapObjectId);

        Dictionary<string, Trigger> GetTriggers();

        Dictionary<string, MapObject> GetMapObjects();
    }
}
