using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class MovieCastCharacter
    {
        public long MovieCastId{ get; set; }
        public MovieCast MovieCast { get; set; }
        public long CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
