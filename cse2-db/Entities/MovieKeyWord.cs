using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class MovieKeyWord
    {
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public long KeyWordId { get; set; }
        public KeyWord KeyWord { get; set; }
    }
}
