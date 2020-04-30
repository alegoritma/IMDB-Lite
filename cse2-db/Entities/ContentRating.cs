using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class ContentRating
    {
        public short Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        //public ICollection<MovieContentRating> MovieContentRatings { get; set; }
        //public ICollection<TvSeriesContentRating> TvSeriesContentRatings { get; set; }
    }
}
