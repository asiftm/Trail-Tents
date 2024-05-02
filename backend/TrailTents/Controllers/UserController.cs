using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text.Json;
using TrailTents.Database;
using TrailTents.Models;


namespace TrailTents.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private DataInterface _dataInterface;
        public UserController(DataInterface dataInterface)
        {
            _dataInterface = dataInterface;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_dataInterface.GetAllUsers());
        }
        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            User user = _dataInterface.GetUserByID(id);
            if (user.Firstname != null) return Ok(user);
            return BadRequest("Invalid ID");
        }
        /*[HttpGet("{id}/Reviews")]
        public ActionResult<User> GetUserByID(int id)
        {
            User user = _dataInterface.GetUserByID(id);
            if (user.Firstname != null) return Ok(user);
            return BadRequest("Invalid ID");

        }*/
        [HttpPost]
        public ActionResult PostUser([FromBody] User user)
        {
            _dataInterface.AddUser(user);
            return Ok(user);
        }
        /*[HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (_dataInterface.UpdateUser(user,id)) return Ok();
            return BadRequest(user);
        }*/
    }
}
