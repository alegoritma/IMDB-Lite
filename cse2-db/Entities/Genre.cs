using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class Genre
    {
        public long Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        //public ICollection<MovieGenre> MovieGenres { get; set; }
        //public ICollection<TvEpisodeGenre> TvEpisodeGenres { get; set; }
    }
}
