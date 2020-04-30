using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class MovieCompany
    {
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
