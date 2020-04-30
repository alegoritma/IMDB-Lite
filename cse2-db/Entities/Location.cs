using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class Location
    {
        public long Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        //public ICollection<MovieLocation> MovieLocations { get; set; }
        //public ICollection<TvEpisodeLocation> TvEpisodeLocations { get; set; }
    }
}