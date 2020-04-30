using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class MovieCountry
    {
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public long CountryId { get; set; }
        public Country Country { get; set; }
        
    }
}
