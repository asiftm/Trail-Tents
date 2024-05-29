using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Newtonsoft.Json;
using System.Text.Json;
using TrailTents.Database;
using TrailTents.Models;


namespace TrailTents.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private IAnonymousDataContext _anonymousDataContext;
        public UserController(IAnonymousDataContext anonymousDataContext)
        {
            _anonymousDataContext = anonymousDataContext;
        }
        [HttpGet]
        public ActionResult GetUsers()
        {
            return Ok(_anonymousDataContext.GetAllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            User user = _anonymousDataContext.GetUserByID(id);
            if (user.Firstname != null) return Ok(user);
            return BadRequest("Invalid ID");
        }

        [HttpGet("{id}/Reviews")]
        public ActionResult GetReviews(int id)
        {
            try
            {
                return Ok(_anonymousDataContext.GetReviewsByUserID(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid ID");
            }
        }

        [HttpPost]
        public ActionResult PostUser([FromBody] User user)
        {
            if (_anonymousDataContext.AddUser(user)) return Ok();
            return BadRequest(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (_anonymousDataContext.UpdateUser(user,id)) return Ok();
            return BadRequest(user);
        }

        [HttpGet("Verification")]
        public ActionResult VerifyUser(string email, string password)
        {
            User user = _anonymousDataContext.VerifyUser(email,password);
            try
            {
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid ID");
            }
        }

        [HttpGet("{email}/UniqueEmail")]
        public bool UniqueEmail(string email)
        {
            User user = new User();
            if(user.UniqueEmail(email)) return (true);
            return (false);
        }
    }
}
