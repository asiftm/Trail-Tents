namespace TrailTents.Models
{
    public class Review
    {
        public int ID { get; private set; }
        public int CampsiteID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
