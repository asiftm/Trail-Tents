namespace TrailTents.Models
{
    public class Booking
    {
        public int ID { get; private set; }
        public int CampsiteID { get; set; }
        public int UserID { get; set; }
        public string BookingStartDate { get; set; }
        public string BookingEndDate { get; set; }
    }
}
