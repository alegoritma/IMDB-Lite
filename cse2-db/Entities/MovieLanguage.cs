namespace cse2_db.Entities
{
    public class MovieLanguage
    {
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}