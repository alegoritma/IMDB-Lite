using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvSeriesPlatform
    {
        public long TvSeriesId { get; set; }
        public TvSeries TvSeries { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
