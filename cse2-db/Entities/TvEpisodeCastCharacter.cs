using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvEpisodeCastCharacter
    {
        public long TvEpisodeCastId { get; set; }
        [JsonIgnore]
        public TvEpisodeCast TvEpisodeCast { get; set; }
        public long CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
