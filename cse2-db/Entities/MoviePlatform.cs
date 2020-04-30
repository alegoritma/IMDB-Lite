using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class MoviePlatform
    {
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
