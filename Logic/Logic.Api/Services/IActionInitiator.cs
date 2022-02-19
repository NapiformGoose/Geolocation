using Action = Geolocation.Logic.Api.Models.Action;

namespace Geolocation.Logic.Api.Services
{
    public interface IActionInitiator : IObservable
    {
        void Initiate(List<Action> actions);
    }
}
