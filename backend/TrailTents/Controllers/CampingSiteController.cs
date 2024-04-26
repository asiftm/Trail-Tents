using Microsoft.AspNetCore.Mvc;
using TrailTents.Database;
using TrailTents.Models;

namespace TrailTents.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CampingSiteController : ControllerBase
    {
        private DataInterface _dataContextInterface;
        public CampingSiteController(DataInterface dataContextInterface)
        {
            _dataContextInterface = dataContextInterface;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CampingSite>> GetAllCampingSites()
        {
            return Ok(_dataContextInterface.GetAllCampingSites());
        }
        [HttpGet("{id}")]
        public ActionResult<CampingSite> GetCampsite(int id)
        {
            CampingSite campingSite = _dataContextInterface.GetCampingSiteByID(id);
            if (campingSite.Name != null) return Ok(campingSite);
            return BadRequest("Invalid ID");
        }
        /*[HttpGet("{id}/Reviews")]
        public ActionResult GetReviews(int id)
        {
            try
            {
                return Ok(_dataContextInterface.GetReviewsByCampingSiteID(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid ID");
            }
        }*/
        [HttpPost]
        public ActionResult PostCampingSite([FromBody] CampingSite campingSite)
        {
            _dataContextInterface.AddCampingSite(campingSite);
            return Ok();
        }
        /*[HttpPut("{id}")]
        public IActionResult UpdateCampingSite(int id, [FromBody] CampingSite campingSite)
        {
            if (_dataContextInterface.UpdateCampingSite(campingSite,id)) return Ok();
            return BadRequest(campingSite);
        }*/
    }
}
