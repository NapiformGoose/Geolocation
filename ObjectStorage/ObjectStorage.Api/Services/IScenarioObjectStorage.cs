using Geolocation.Logic.Api.Models;

namespace Geolocation.ObjectStorage.Api.Services
{
    public interface IScenarioObjectStorage
    {
        Scenario Get(string scenarioId);

        string Add(Scenario scenario);

        Scenario Edit(Scenario scenario);

        string Delete(string scenarioId);

        List<Scenario> List();
    }
}
