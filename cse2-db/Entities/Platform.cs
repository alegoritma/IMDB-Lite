using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class Platform
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Url { get; set; }
        [MaxLength(5000)]
        public string Description { get; set; }
        //public ICollection<TvSeriesPlatform> TvSeriesPlatforms { get; set; }
        //public ICollection<MoviePlatform> MoviePlatforms { get; set; }
    }
}
