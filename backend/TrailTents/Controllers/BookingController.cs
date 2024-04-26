using Microsoft.AspNetCore.Mvc;
using TrailTents.Database;
using TrailTents.Models;

namespace TrailTents.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BookingController : ControllerBase
    {
        private DataInterface _dataContextInterface;
        public BookingController(DataInterface dataContextInterface)
        {
            _dataContextInterface = dataContextInterface;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetAllBookings()
        {
            return Ok(_dataContextInterface.GetAllBookings());
        }
        [HttpGet("{id}")]
        public ActionResult<Booking> GetBooking(int id)
        {
            Booking booking = _dataContextInterface.GetBookingByID(id);
            if (booking.CampsiteID != null) return Ok(booking);
            return BadRequest("Invalid ID");
        }
        [HttpPost]
        public ActionResult PostBookings([FromBody] Booking booking)
        {
            _dataContextInterface.AddBooking(booking);
            return Ok(booking);
        }
        
    }
}
