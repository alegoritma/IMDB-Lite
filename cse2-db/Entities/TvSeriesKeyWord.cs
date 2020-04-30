using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvSeriesKeyWord
    {
        public long TvSeriesId { get; set; }
        public TvSeries TvSeries { get; set; }
        public long KeyWordId { get; set; }
        public KeyWord KeyWord { get; set; }
    }
}
