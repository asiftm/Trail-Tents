using Microsoft.AspNetCore.Mvc;
using TrailTents.Database;
using TrailTents.Models;

namespace TrailTents.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BookingController : Controller
    {
        private IAnonymousDataContext _anonymousDataContext;
        public BookingController(IAnonymousDataContext anonymousDataContext)
        {
            _anonymousDataContext = anonymousDataContext;
        }
        [HttpGet]
        public ActionResult GetBookings()
        {
            return Ok(_anonymousDataContext.GetAllBookings());
        }
        [HttpGet("{id}")]
        public ActionResult GetBooking(int id)
        {
            Booking booking = _anonymousDataContext.GetBookingByID(id);
            if (booking.CampsiteID != null) return Ok(booking);
            return BadRequest("Invalid ID");
        }
        [HttpPost]
        public ActionResult PostBookings([FromBody] Booking booking)
        {
            if(_anonymousDataContext.AddBooking(booking)) return Ok(booking);
            return BadRequest();
        }
        
    }
}
