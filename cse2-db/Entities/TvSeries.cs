using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class TvSeries
    {
        public long Id { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string StoryLine { get; set; }
        //public ICollection<TvSeriesKeyWord> KeyWords { get; set; }
        //public List<Genre> Genres { get; set; }
        public DateTime PublishDate { get; set; }
        public long? ImageId { get; set; }
        public Image Image { get; set; }
        public int? Duration { get; set; }
        //Languages
        public short? ContentRatingId { get; set; }
        public ContentRating ContentRating { get; set; }
        public float AvgRating { get; set; }
        public long VotesCount { get; set; } //Save in relation?
        [MaxLength(50)]
        public string ImdbId { get; set; }
        public ICollection<Season> Seasons { get; set; }
        //public ICollection<TvSeriesPlatform> TvSeriesPlatforms { get; set; }
    }
}
