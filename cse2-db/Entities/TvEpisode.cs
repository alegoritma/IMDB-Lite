using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvEpisode
    {
        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            throw new NotImplementedException();
            return ((TvEpisode)obj).Id == Id;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return Id.GetHashCode();
        }
        public long Id { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string? StoryLine { get; set; }
        //public ICollection<TvEpisodeKeyWord> KeyWords { get; set; }
        public int EpisodeNumber { get; set; }
        public long SeasonId { get; set; }
        public Season Season { get; set; }
        public DateTime? AirDate { get; set; }
        public long? ImageId { get; set; }
        public Image Image { get; set; } //?
        public int? Duration { get; set; }
        public float AvgRating { get; set; }
        public long VotesCount { get; set; } //Save in relation?
        [MaxLength(50)]
        public string ImdbId { get; set; }
        //public ICollection<TvEpisodeLanguage> Languages { get; set; }
        //public ICollection<TvEpisodeGenre> TvEpisodeGenres { get; set; }
        //public ICollection<TvEpisodeCountry> TvEpisodeCountries { get; set; }
        //public ICollection<TvEpisodeLocation> TvEpisodeLocations { get; set; }
        //public ICollection<TvEpisodeCompany> TvEpisodeCompanies { get; set; }
        //public ICollection<TvEpisodeCast> TvEpisodeCasts { get; set; }
        //public ICollection<TvEpisodeDirector> TvEpisodeDirectors { get; set; }
        //public ICollection<TvEpisodeProducer> TvEpisodeProducers { get; set; }
        //public ICollection<TvEpisodeWriter> TvEpisodeWriters { get; set; }
    }
}
