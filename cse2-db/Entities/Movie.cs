using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    
    public class Movie
    {
        public long Id { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string? StoryLine { get; set; }
        //public ICollection<MovieKeyWord> MovieKeyWords { get; set; }
        //public ICollection<MovieLanguage> MovieLanguages { get; set; }
        public DateTime? AirDate { get; set; }
        public long? ImageId { get; set; }
        public Image? Image { get; set; } //?
        public short? ContentRatingId { get; set; }
        public ContentRating ContentRating { get; set; }
        public int Duration { get; set; }
        public float AvgRating { get; set; }
        public long VotesCount { get; set; } //Save in relation?
        [MaxLength(50)]
        public string ImdbId { get; set; }
        //public ICollection<MoviePlatform> MoviePlatforms { get; set; }
        //public ICollection<MovieGenre> MovieGenres { get; set; }
        //public ICollection<MovieCountry> MovieCountries { get; set; }
        //public ICollection<MovieLocation> MovieLocations { get; set; }
        //public ICollection<MovieCompany> MovieCompanies { get; set; }
        //public ICollection<MovieCast> MovieCasts { get; set; }
        //public ICollection<MovieDirector> MovieDirectors { get; set; }
        //public ICollection<MovieProducer> MovieProducers { get; set; }
        //public ICollection<MovieWriter> MovieWriters { get; set; }

    }
}
