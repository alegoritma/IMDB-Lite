using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvEpisodeLanguage
    {
        public long TvEpisodeId { get; set; }
        public TvEpisode TvEpisode { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
