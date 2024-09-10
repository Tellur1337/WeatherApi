namespace PogodaApp.API
{
    public class GeoObject
    {
        public District district { get; set; }
        public Locality locality { get; set; }
        public Province province { get; set; }
        public Country country { get; set; }
    }
}
