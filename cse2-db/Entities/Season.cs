using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class Season
    {
        public long Id { get; set; }
        public int SeasonNumber { get; set; }
        public List<TvEpisode> TvEpisodes { get; set; }
        public long TvSeriesId { get; set; }
        public TvSeries TvSeries { get; set; }
        [MaxLength(50)]
        public string TVSeriesImdbId { get; set; }
        [MaxLength(50)]
        public string ImdbId { get; set; } //S{i}{TvSeries.ImdbId}
    }
}
