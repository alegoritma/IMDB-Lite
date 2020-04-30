using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class MovieProducer
    {
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
