using System.Collections.Generic;

namespace PogodaApp.API
{
    public class Forecast
    {
        public string date { get; set; }
        public double date_ts { get; set; }
        public double week { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string rise_begin { get; set; }
        public string set_end { get; set; }
        public double moon_code { get; set; }
        public string moon_text { get; set; }
        public Parts parts { get; set; }
        public List<object> hours { get; set; }
        public Biomet biomet { get; set; }
    }
}
