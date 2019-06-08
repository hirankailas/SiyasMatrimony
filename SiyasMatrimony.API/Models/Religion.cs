using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiyasMatrimony.API.Models
{
    public class Religion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Caste> Castes { get; set; }
    }
}
