using Geolocation.Logic.Api.Models;
using Geolocation.Logic.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Geolocation.API.Controllers
{
    [ApiController]
    [Route("api/Scenario")]
    public class ScenarioController : ControllerBase
    {
        private readonly IScenarioService _scenarioService;

        public ScenarioController(IScenarioService scenarioService)
        {
            _scenarioService = scenarioService;
        }

        [HttpGet]
        [Route("Get/{scenarioId}")]
        public ActionResult Get(string scenarioId)
        {
            var scenario = _scenarioService.Get(scenarioId);
            return new ObjectResult(scenario);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create([FromBody] Scenario scenario)
        {
            var scenarioId = _scenarioService.Create(scenario);
            return Ok(scenarioId);
        }

        [HttpPut]
        [Route("Edit")]
        public ActionResult Edit([FromBody] Scenario scenario)
        {
            var editedScenario = _scenarioService.Edit(scenario);
            return new ObjectResult(editedScenario);
        }

        [HttpDelete]
        [Route("Delete/{scenarioId}")]
        public ActionResult Delete(string scenarioId)
        {
            _scenarioService.Delete(scenarioId);
            return Ok(scenarioId);
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            var scenarios = _scenarioService.List();
            return new ObjectResult(scenarios);
        }
    }
}
