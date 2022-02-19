using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Logic.Api.Services
{
    public interface ITriggerInitiator : IObservable
    {
        void Initiate();
    }
}
