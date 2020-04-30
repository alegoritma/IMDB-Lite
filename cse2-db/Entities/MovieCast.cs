using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class MovieCast
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
        //public ICollection<MovieCastCharacter> MovieCastCharacters { get; set; }
        public int Importance { get; set; }
    }
}
