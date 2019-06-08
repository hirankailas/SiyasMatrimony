using System.Collections.Generic;

namespace SiyasMatrimony.API.Models
{
    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
        public Country Country { get; set; }
        public int country_id { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}