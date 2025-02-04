﻿namespace PogodaApp.API
{
    public class Morning
    {
        public string _source { get; set; }
        public double temp_min { get; set; }
        public double temp_avg { get; set; }
        public double temp_max { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public double fresh_snow_mm { get; set; }
    }
}
