namespace TrailTents.Models
{
    public class CampingSite
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int PricePerDay { get; set; }
        public float Rating { get; set; }
    }
}
