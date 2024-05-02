using Microsoft.AspNetCore.Mvc;
using TrailTents.Database;
using TrailTents.Models;

namespace TrailTents.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class AdminController : Controller
    {
        private IAnonymousDataContext _anonymousDataContext;
        public AdminController(IAnonymousDataContext anonymousDataContext)
        {
            _anonymousDataContext = anonymousDataContext;
        }
        [HttpGet]
        public ActionResult GetAdmins()
        {
            return Ok(_anonymousDataContext.GetAllAdmins());
        }
        [HttpGet("{id}")]
        public ActionResult GetAdmin(int id)
        {
            Admin admin = _anonymousDataContext.GetAdminByID(id);
            if (admin.Firstname != null) return Ok(admin);
            return BadRequest("Invalid ID");
        }
        [HttpPost]
        public ActionResult PostAdmin([FromBody] Admin admin)
        {
            if (_anonymousDataContext.AddAdmin(admin)) return Ok();
            return BadRequest(admin);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, [FromBody] Admin admin)
        {
            if (_anonymousDataContext.UpdateAdmin(admin,id)) return Ok();
            return BadRequest(admin);
        }
    }
}
