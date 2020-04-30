using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class MovieGenre
    {
        public long GenreId { get; set; }
        public Genre Genre { get; set; }
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
