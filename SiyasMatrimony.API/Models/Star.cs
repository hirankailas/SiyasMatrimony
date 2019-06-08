using System.Collections.Generic;

namespace SiyasMatrimony.API.Models
{
    public class Star
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Rashi> Rashi { get; set; }
    }
}