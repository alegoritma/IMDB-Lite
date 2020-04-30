using cse2_db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.DOTs
{
    public class CastInfoDto
    {
        public Person Person { get; set; }
        public int Importance { get; set; }
        public List<Character> Characters { get; set; }
    }
}
