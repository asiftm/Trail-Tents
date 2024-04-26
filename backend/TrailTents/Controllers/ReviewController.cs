using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TrailTents.Database;
using TrailTents.Models;

namespace TrailTents.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ReviewController : ControllerBase
    {
        private DataInterface _dataContextInterface;
        public ReviewController(DataInterface dataContextInterface)
        {
            _dataContextInterface = dataContextInterface;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetReviews()
        {
            return Ok(_dataContextInterface.GetAllReviews());
        }
        [HttpGet("{id}")]
        public ActionResult<Review> GetReview(int id)
        {
            Review review = _dataContextInterface.GetReviewByID(id);
            if (review.Rating != null) return Ok(review);
            return BadRequest("Invalid ID");
        }
        [HttpPost]
        public ActionResult PostReview([FromBody] Review review)
        {
            _dataContextInterface.AddReview(review);
            return Ok();
        }
    }
}
