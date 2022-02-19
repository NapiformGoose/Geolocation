using Geolocation.API.Dto;
using Geolocation.Logic.Api.Enums;
using Geolocation.Logic.Api.Models;
using Geolocation.Logic.Api.Services;
using Microsoft.AspNetCore.SignalR;

namespace Geolocation.API
{
    public class ScenarioHub : Hub
    {
        private readonly IScenarioManager _scenarioManager;

        public ScenarioHub(IScenarioManager scenarioManager)
        {
            _scenarioManager = scenarioManager;
        }

        public async Task UpdateMapObjectPosition(MapObject mapObject)
        {
            _scenarioManager.UpdateMapObjectState(mapObject);
            var updatedMapObjects = _scenarioManager.GetUpdatedMapObjects();

            var actualScenarioData = new ActualScenarioData
            {
                MapObjects = updatedMapObjects,
                Tasks = new List<ScenarioTask> { new ScenarioTask (Guid.NewGuid().ToString(), "taskTestName", ScenarioTaskStatus.Сompleted) }
            };
            await this.Clients.All.SendAsync("GetActualScenarioData", actualScenarioData);
        }
    }
}
