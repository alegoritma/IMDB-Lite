using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvEpisodeGenre
    {
        public long TvEpisodeId { get; set; }
        public TvEpisode TvEpisode { get; set; }
        public long GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
