using Geolocation.Logic.Api.Models;

namespace Geolocation.Logic.Api.Services
{
    public interface IScenarioService
    {
        Scenario Get(string scenarioId);

        string Create(Scenario scenario);

        Scenario Edit(Scenario scenario);

        string Delete(string scenarioId);

        List<Scenario> List();
    }
}
