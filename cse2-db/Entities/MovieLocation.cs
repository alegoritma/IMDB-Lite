using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class MovieLocation
    {
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public long LocationId { get; set; }
        public Location Location { get; set; }
    }
}
