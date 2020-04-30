using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvEpisodeKeyWord
    {
        public long TvEpisodeId { get; set; }
        public TvEpisode TvEpisode { get; set; }
        public long KeyWordId { get; set; }
        public KeyWord KeyWord { get; set; }
    }
}
