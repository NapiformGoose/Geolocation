using Geolocation.Logic.Api.Models;
using Geolocation.Logic.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Geolocation.API.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Get/{userId}")]
        public ActionResult Get(string userId)
        {
            var user = _userService.Get(userId);
            return new ObjectResult(user);
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create([FromBody] User user)
        {
            var userId = _userService.Create(user);
            return Ok(userId);
        }

        [HttpPut]
        [Route("Edit")]
        public ActionResult Edit([FromBody] User user)
        {
            var editedUser = _userService.Edit(user);
            return new ObjectResult(editedUser);
        }

        [HttpDelete]
        [Route("Delete/{userId}")]
        public ActionResult Delete(string userId)
        {
            _userService.Delete(userId);
            return Ok(userId);
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            var users = _userService.List();
            return new ObjectResult(users);
        }
    }
}
