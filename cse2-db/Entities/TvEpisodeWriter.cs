using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvEpisodeWriter
    {
        public long TvEpisodeId { get; set; }
        [JsonIgnore]
        public TvEpisode TvEpisode { get; set; }
        public long PersonId { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
    }
}
