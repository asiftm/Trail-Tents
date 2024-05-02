using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TrailTents.Database;
using TrailTents.Models;

namespace TrailTents.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ReviewController : Controller
    {
        private IAnonymousDataContext _anonymousDataContext;
        public ReviewController(IAnonymousDataContext anonymousDataContext)
        {
            _anonymousDataContext = anonymousDataContext;
        }
        [HttpGet]
        public ActionResult GetReviews()
        {
            return Ok(_anonymousDataContext.GetAllReviews());
        }
        [HttpGet("{id}")]
        public ActionResult GetReview(int id)
        {
            Review review = _anonymousDataContext.GetReviewByID(id);
            if (review.Rating != null) return Ok(review);
            return BadRequest("Invalid ID");
        }
        [HttpPost]
        public ActionResult PostReview([FromBody] Review review)
        {
            if (_anonymousDataContext.AddReview(review)) return Ok();
            return BadRequest(review);
        }
    }
}
