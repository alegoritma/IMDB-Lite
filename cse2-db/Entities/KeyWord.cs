using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class KeyWord
    {
        public long Id { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        //public ICollection<TvSeriesKeyWord> TvSeriesKeyWords { get; set; }
        //public ICollection<MovieKeyWord> MovieKeyWords { get; set; }
        //public ICollection<TvEpisodeKeyWord> TvEpisodeKeyWords { get; set; }
    }
}
