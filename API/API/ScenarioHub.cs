using Geolocation.API.Dto;
using Geolocation.ObjectStorage.Api.Enums;
using Geolocation.ObjectStorage.Api.Models;
using Microsoft.AspNetCore.SignalR;

namespace Geolocation.API
{
    public class ScenarioHub : Hub
    {
        public async Task UpdateMapObjectPosition(MapObject mapObject)
        {
            //todo run logic
            var actualScenarioData = new ActualScenarioData
            {
                MapObjects = new List<MapObject> { mapObject },
                Tasks = new List<ScenarioTask> { new ScenarioTask (1, "taskTestName", ScenarioTaskStatus.Сompleted) }
            };
            await this.Clients.All.SendAsync("GetActualScenarioData", actualScenarioData);
        }
    }
}
