using Microsoft.AspNetCore.Mvc;
using TrailTents.Database;
using TrailTents.Models;

namespace TrailTents.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CampingSiteController : Controller
    {
        private IAnonymousDataContext _anonymousDataContext;
        public CampingSiteController(IAnonymousDataContext anonymousDataContext)
        {
            _anonymousDataContext = anonymousDataContext;
        }

        [HttpGet]
        public ActionResult GetCampingSites()
        {
            return Ok(_anonymousDataContext.GetAllCampingSites());
        }
        [HttpGet("{id}")]
        public ActionResult GetCampsite(int id)
        {
            CampingSite campingSite = _anonymousDataContext.GetCampingSiteByID(id);
            if (campingSite.Name != null) return Ok(campingSite);
            return BadRequest("Invalid ID");
        }
        [HttpGet("{id}/Reviews")]
        public ActionResult GetReviews(int id)
        {
            try
            {
                return Ok(_anonymousDataContext.GetReviewsByCampingSiteID(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid ID");
            }
        }
        [HttpPost]
        public ActionResult PostCampingSite([FromBody] CampingSite campingSite)
        {
            _anonymousDataContext.AddCampingSite(campingSite);
            return Ok(campingSite);
            if (_anonymousDataContext.AddCampingSite(campingSite)) return Ok();
            return BadRequest(campingSite);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCampingSite(int id, [FromBody] CampingSite campingSite)
        {
            if (_anonymousDataContext.UpdateCampingSite(campingSite,id)) return Ok();
            return BadRequest(campingSite);
        }
    }
}
