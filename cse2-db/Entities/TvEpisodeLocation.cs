using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvEpisodeLocation
    {
        public long TvEpisodeId { get; set; }
        public TvEpisode TvEpisode { get; set; }
        public long LocationId { get; set; }
        public Location Location { get; set; }
    }
}
