using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class Person
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public long? ImageId { get; set; }
        public Image Image { get; set; }
        [MaxLength(50)]
        public string ImdbId { get; set; }
        //public ICollection<TvEpisodeCast> TvEpisodeCasts { get; set; }
        //public ICollection<TvEpisodeDirector> TvEpisodeDirectors { get; set; }
        //public ICollection<TvEpisodeProducer> TvEpisodeProducers { get; set; }
        //public ICollection<TvEpisodeWriter> TvEpisodeWriters { get; set; }
        //public ICollection<MovieCast> MovieCasts { get; set; }
        //public ICollection<MovieDirector> MovieDirectors { get; set; }
        //public ICollection<MovieProducer> MovieProducers { get; set; }
        //public ICollection<MovieWriter> MovieWriters { get; set; }

    }
}
