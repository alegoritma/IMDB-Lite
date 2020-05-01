using cse2_db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.DataAccess
{
    public class MediaContext: DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ContentRating> ContentRatings { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCastCharacter> MovieCastCharacters { get; set; }
        public DbSet<MovieCompany> MovieCompanies { get; set; }
        public DbSet<MovieCountry> MovieCountries { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieKeyWord> MovieKeyWords { get; set; }
        public DbSet<MovieLanguage> MovieLanguages { get; set; }
        public DbSet<MovieLocation> MovieLocations { get; set; }
        public DbSet<MoviePlatform> MoviePlatforms { get; set; }
        public DbSet<MovieProducer> MovieProducers { get; set; }
        public DbSet<MovieWriter> MovieWriters { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<TvEpisode> TvEpisodes { get; set; }
        public DbSet<TvEpisodeCast> TvEpisodeCasts { get; set; }
        public DbSet<TvEpisodeCastCharacter> TvEpisodeCastCharacters { get; set; }
        public DbSet<TvEpisodeCompany> TvEpisodeCompanies { get; set; }
        public DbSet<TvEpisodeCountry> TvEpisodeCountries { get; set; }
        public DbSet<TvEpisodeDirector> TvEpisodeDirectors { get; set; }
        public DbSet<TvEpisodeGenre> TvEpisodeGenres { get; set; }
        public DbSet<TvEpisodeKeyWord> TvEpisodeKeyWords { get; set; }
        public DbSet<TvEpisodeLanguage> TvEpisodeLanguages { get; set; }
        public DbSet<TvEpisodeLocation> TvEpisodeLocations { get; set; }
        public DbSet<TvEpisodeProducer> TvEpisodeProducers { get; set; }
        public DbSet<TvEpisodeWriter> TvEpisodeWriters { get; set; }
        public DbSet<TvSeries> TvSeries { get; set; }
        public DbSet<TvSeriesKeyWord> TvSeriesKeyWords { get; set; }
        public DbSet<TvSeriesPlatform> TvSeriesPlatforms { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //Override default naming convention which uses plural names. Use singular.
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                //.DisplayName() refers string convention of the object
                entityType.SetTableName(entityType.DisplayName());
            }

            //modelBuilder.Entity<Character>()
            //   .HasMany(c => c.TvEpisodeCastCharacters)
            //   .WithOne(tcc => tcc.Character)
            //   .HasForeignKey(_c => _c.CharacterId);

            //modelBuilder.Entity<MovieCastCharacter>()
            //    .HasOne(mcc => mcc.Character)
            //    .WithMany(c => c.MovieCastCharacters)
            //    .HasForeignKey(mcc => mcc.CharacterId);
            //modelBuilder.Entity<MovieCastCharacter>()
            //    .HasOne(mcc => mcc.MovieCast)
            //    .WithMany(mc => mc.MovieCastCharacters)
            //    .HasForeignKey(mcc => mcc.MovieCastId);

            //modelBuilder.Entity<TvEpisodeCastCharacter>()
            //   .HasOne(tcc => tcc.Character)
            //   .WithMany(c => c.TvEpisodeCastCharacters)
            //   .HasForeignKey(tcc => tcc.CharacterId);
            //modelBuilder.Entity<TvEpisodeCastCharacter>()
            //    .HasOne(tcc => tcc.TvEpisodeCast)
            //    .WithMany(tc => tc.TvEpisodeCastCharacters)
            //    .HasForeignKey(tcc => tcc.TvEpisodeCastId);

            //modelBuilder.Entity<MovieCountry>()
            //    .HasOne(mc => mc.Country)
            //    .WithMany(c => c.MovieCountries)
            //    .HasForeignKey(mc => mc.CountryId);

            //modelBuilder.Entity<MovieCountry>()
            //    .HasOne(mc => mc.Movie)
            //    .WithMany(m => m.MovieCountries)
            //    .HasForeignKey(mc => mc.MovieId);

            

            modelBuilder.Entity<MovieCastCharacter>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeCastCharacter>()
                .HasKey(x => new { x.CharacterId, x.TvEpisodeCastId });
            modelBuilder.Entity<MovieCompany>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeCompany>()
                .HasNoKey();
            modelBuilder.Entity<MovieCountry>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeCountry>()
                .HasNoKey();
            modelBuilder.Entity<MovieDirector>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeDirector>()
                .HasKey(x => new { x.PersonId, x.TvEpisodeId });
            modelBuilder.Entity<MovieGenre>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeGenre>()
                .HasNoKey();
            modelBuilder.Entity<MovieKeyWord>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeKeyWord>()
                .HasNoKey();
            modelBuilder.Entity<MovieLanguage>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeLanguage>()
                .HasNoKey();
            modelBuilder.Entity<MovieKeyWord>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeKeyWord>()
                .HasNoKey();
            modelBuilder.Entity<TvSeriesKeyWord>()
                .HasNoKey();
            modelBuilder.Entity<MovieLocation>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeLocation>()
                .HasNoKey();
            modelBuilder.Entity<MovieProducer>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeProducer>()
                .HasKey(x => new { x.PersonId, x.TvEpisodeId });
            modelBuilder.Entity<MovieWriter>()
                .HasNoKey();
            modelBuilder.Entity<TvEpisodeWriter>()
                .HasKey(x => new { x.PersonId, x.TvEpisodeId });
            modelBuilder.Entity<MoviePlatform>()
                .HasNoKey();
            modelBuilder.Entity<TvSeriesPlatform>()
                .HasNoKey();

            modelBuilder.Entity<Character>()
                .HasIndex(e => e.Name);

            modelBuilder.Entity<Company>()
               .HasIndex(e => e.Name);

            modelBuilder.Entity<ContentRating>()
                .HasIndex(e => e.Name);

            modelBuilder.Entity<Country>()
                .HasIndex(e => e.Name);

            modelBuilder.Entity<Genre>()
                .HasIndex(e => e.Name);

            modelBuilder.Entity<Language>()
                .HasIndex(e => e.Name);

            modelBuilder.Entity<Location>()
                .HasIndex(e => e.Name);

            modelBuilder.Entity<KeyWord>()
                .HasIndex(e => e.Name);

            modelBuilder.Entity<Movie>()
                .HasIndex(e => e.Title);
            modelBuilder.Entity<Movie>()
                .HasIndex(e => e.Duration);
            modelBuilder.Entity<Movie>()
                .HasIndex(e => e.AirDate);
            modelBuilder.Entity<Movie>()
                .HasIndex(e => e.AvgRating);
            modelBuilder.Entity<Movie>()
                .HasIndex(e => e.VotesCount);
            modelBuilder.Entity<Movie>()
                .HasIndex(e => e.ImdbId);

            modelBuilder.Entity<MovieCast>()
                .HasIndex(e => e.Importance);

            modelBuilder.Entity<Person>()
                .HasIndex(e => e.FullName);
            modelBuilder.Entity<Person>()
                .HasIndex(e => e.BirthDate);
            modelBuilder.Entity<Person>()
                .HasIndex(e => e.DeathDate);
            modelBuilder.Entity<Person>()
                .HasIndex(e => e.ImdbId);

            modelBuilder.Entity<Platform>()
                .HasIndex(e => e.Name);

            modelBuilder.Entity<Season>()
              .HasIndex(e => e.SeasonNumber);
            modelBuilder.Entity<Season>()
              .HasIndex(e => e.TVSeriesImdbId);
            modelBuilder.Entity<Season>()
              .HasIndex(e => e.ImdbId);

            modelBuilder.Entity<TvEpisode>()
              .HasIndex(e => e.Title);
            modelBuilder.Entity<TvEpisode>()
              .HasIndex(e => e.Duration);
            modelBuilder.Entity<TvEpisode>()
              .HasIndex(e => e.EpisodeNumber);
            modelBuilder.Entity<TvEpisode>()
              .HasIndex(e => e.AirDate);
            modelBuilder.Entity<TvEpisode>()
              .HasIndex(e => e.AvgRating);
            modelBuilder.Entity<TvEpisode>()
              .HasIndex(e => e.VotesCount);
            modelBuilder.Entity<TvEpisode>()
              .HasIndex(e => e.ImdbId);

            modelBuilder.Entity<TvEpisodeCast>()
              .HasIndex(e => e.Importance);

            modelBuilder.Entity<TvSeries>()
              .HasIndex(e => e.Title);
            modelBuilder.Entity<TvSeries>()
                .HasIndex(e => e.Duration);
            modelBuilder.Entity<TvSeries>()
              .HasIndex(e => e.AvgRating);
            modelBuilder.Entity<TvSeries>()
              .HasIndex(e => e.VotesCount);
            modelBuilder.Entity<TvSeries>()
              .HasIndex(e => e.ImdbId);

    

        }
        
        //To use postgresql, use this method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql(
                "Host=localhost;Database=IMDBLite2;Username=IMDB_API_USER;Password=123456"
                );
            //Add-Migration InitialCreate
            //Update-Database
        }


    }
}