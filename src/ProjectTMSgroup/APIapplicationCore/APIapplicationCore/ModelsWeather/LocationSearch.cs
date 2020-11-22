using System;
using System.Collections.Generic;
using System.Text;

namespace APIapplicationCore.ModelsWeather
{
    public class ExampleSearch
    {
        public string title { get; set; }
        public string location_type { get; set; }
        public int woeid { get; set; }
        public string latt_long { get; set; }
    }
}
