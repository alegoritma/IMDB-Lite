using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class Country
    {
        public long Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        //public ICollection<MovieCountry> MovieCountries { get; set; }
        //public ICollection<TvEpisodeCountry> TvEpisodeCountries { get; set; }
    }
}
