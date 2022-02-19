using Geolocation.Logic.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Logic.Api.Services
{
    public interface IScenarioManager
    {
        void UpdateMapObjectState(MapObject mapObject);

        List<MapObject> GetUpdatedMapObjects();
    }
}
