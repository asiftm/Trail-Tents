using Microsoft.AspNetCore.Mvc;
using TrailTents.Database;
using TrailTents.Models;

namespace TrailTents.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class AdminController : ControllerBase
    {
        private DataInterface _dataInterface;
        public AdminController(DataInterface dataInterface)
        {
            _dataInterface = dataInterface;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Admin>> GetAllAdmins()
        {
            return Ok(_dataInterface.GetAllAdmins());
        }
        [HttpGet("{id}")]
        public ActionResult<Admin> GetAdmin(int id)
        {
            Admin admin = _dataInterface.GetAdminByID(id);
            if (admin.Firstname != null) return Ok(admin);
            return BadRequest("Invalid ID");
        }
        [HttpPost]
        public ActionResult PostAdmin([FromBody] Admin admin)
        {
            _dataInterface.AddAdmin(admin);
            return Ok(admin);
        }
        /*[HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, [FromBody] Admin admin)
        {
            if (_anonymousDataContext.UpdateAdmin(admin,id)) return Ok();
            return BadRequest(admin);
        }*/
    }
}
