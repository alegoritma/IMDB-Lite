using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvEpisodeCompany
    {
        public long TvEpisodeId { get; set; }
        public TvEpisode TvEpisode { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
