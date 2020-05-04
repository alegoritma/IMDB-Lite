using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using cse2_db.DataAccess;
using cse2_db.DOTs;
using cse2_db.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cse2_db.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MediaContext db;
        public MovieController(MediaContext context)
        {
            db = context;
        }
        // Request 4
        // GET: /?{id)
        public async Task<IActionResult> Get(long Id)
        {
            // Complexities: 9
            var companies = await (from Company in db.Companies
                             from MovieCompany in db.MovieCompanies
                             where MovieCompany.MovieId == Id
                             where Company.Id == MovieCompany.CompanyId
                             select Company).ToListAsync();

            var languages = await (from Language in db.Languages
                             from MovieLanguage in db.MovieLanguages
                             where MovieLanguage.MovieId == Id
                             where Language.Id == MovieLanguage.LanguageId
                             select Language).ToListAsync();

            var locations = await (from Location in db.Locations
                             from MovieLocation in db.MovieLocations
                             where MovieLocation.MovieId == Id
                             where Location.Id == MovieLocation.LocationId
                             select Location).ToListAsync();

            var genres = await (from MovieGenre in db.MovieGenres
                          from Genre in db.Genres
                          where MovieGenre.MovieId == Id
                          where Genre.Id == MovieGenre.GenreId
                          select Genre).ToListAsync();

            var countries = await (from MovieCountry in db.MovieCountries
                             from Country in db.Countries
                             where MovieCountry.MovieId == Id
                             where Country.Id == MovieCountry.CountryId
                             select Country).ToListAsync();
            
            var keywords = await (from KeyWord in db.KeyWords
                            from MovieKeyWord in db.MovieKeyWords
                            where MovieKeyWord.MovieId == Id
                            where KeyWord.Id == MovieKeyWord.KeyWordId
                            select KeyWord).ToListAsync();
            
            var directors = await (from MovieDirector in db.MovieDirectors
                             from Person in db.People
                             where MovieDirector.MovieId == Id
                             where MovieDirector.PersonId == Person.Id
                             select new
                             {
                                 PersonId = Person.Id,
                                 Person.FullName,
                                 Person.Image.ImageUrl,
                                 Person.BirthDate,
                                 Person.DeathDate
                             }).ToListAsync();

            var writers = await (from MovieWriter in db.MovieWriters
                           from Person in db.People
                           where MovieWriter.MovieId == Id
                           where MovieWriter.PersonId == Person.Id
                           select new
                           {
                               PersonId = Person.Id,
                               Person.FullName,
                               Person.Image.ImageUrl,
                               Person.BirthDate,
                               Person.DeathDate
                           }).ToListAsync();

            var producers = await (from MovieProducer in db.MovieProducers
                             from Person in db.People
                             where MovieProducer.MovieId == Id
                             where MovieProducer.PersonId == Person.Id
                             select new
                             {
                                 PersonId = Person.Id,
                                 Person.FullName,
                                 Person.Image.ImageUrl,
                                 Person.BirthDate,
                                 Person.DeathDate
                             }).ToListAsync();

            // Complexity: n+1
            var cast = await (from MovieCast in db.MovieCasts
                        from Person in db.People
                        where MovieCast.MovieId == Id
                        where MovieCast.PersonId == Person.Id
                        orderby MovieCast.Importance
                        select new
                        {
                            person = new
                            {
                                PersonId = Person.Id,
                                Person.FullName,
                                Person.Image.ImageUrl,
                                Person.BirthDate,
                                Person.DeathDate
                            },
                            characters = (from Character in db.Characters
                                          from MovieCastCharacter in db.MovieCastCharacters
                                          where MovieCastCharacter.MovieCastId == MovieCast.Id
                                          where Character.Id == MovieCastCharacter.CharacterId
                                          select Character).ToList()
                        }).ToListAsync();

            var platforms = await (from MoviePlatform in db.MoviePlatforms
                             from Platform in db.Platforms
                             where MoviePlatform.MovieId == Id
                             where MoviePlatform.PlatformId == Platform.Id
                             select Platform).ToListAsync();

            // Complexity: 1
            var movie = (from Movie in db.Movies
                          where Movie.Id == Id
                          select new
                          {
                              Movie.Id,
                              Movie.Title,
                              Movie.StoryLine,
                              Movie.AirDate,
                              Movie.Image.ImageUrl,
                              Movie.Duration,
                              Movie.AvgRating,
                              Movie.VotesCount,
                              companies,
                              languages,
                              locations,
                              genres,
                              countries, 
                              keywords,
                              platforms,
                              Crew = new
                              {
                                  directors,
                                  writers,
                                  producers,
                                  cast
                              }
                          });
            
            if (!movie.Any())
                return NotFound(new ResWrapper { Status = "NotFound", args = new { Id }});
            
            return Ok(new ResWrapper{ Status = "OK", args = new { Id }, Data = movie.Single() });
        }

        public async Task<IActionResult> AddLanguage(long movieId, int languageId)
        {
            var language = await db.Languages
                .Where(x => x.Id == languageId)
                .SingleOrDefaultAsync();
            if (language == null)
                return NotFound(new ResWrapper { args = new { movieId, languageId }, Status = "NotFound:Language" });
            
            var movie = await db.Movies
                .Where(x => x.Id == movieId)
                .SingleOrDefaultAsync();
            if (movie == null)
                return NotFound(new ResWrapper { args = new { movieId, languageId }, Status = "NotFound:Movie" });

            var movieLanguage = await db.MovieLanguages
                .Where(x => x.MovieId == movieId && x.LanguageId == languageId)
                .SingleOrDefaultAsync();
            if (movieLanguage != null)
                return Ok(new ResWrapper { args = new { movieId, languageId }, Status = "OK", Data = new { movie, language } });

            movieLanguage = new MovieLanguage { Movie = movie, Language = language, LanguageId = languageId, MovieId = movieId };
            await db.AddAsync(movieLanguage);
            await db.SaveChangesAsync();

            return Ok(new ResWrapper { args = new { movieId, languageId }, Status = "OK", Data = new { movie, language } });
        }

        // Request 8
        public IActionResult Update(long Id, string field, string value)
        {
            var query = (from Movie in db.Movies
                         where Movie.Id == Id
                         select Movie);
            if (!query.Any())
                return NotFound(new ResWrapper { Status = "NotFound", args = new { Id, field, value } });

            var movie = query.Single();
            string OldValue = "";
            //Fields Title, StoryLine, AirDate, Duration, AvgRating, VoteCount
            switch (field.ToLower())
            {
                case "title":
                    OldValue = movie.Title;
                    movie.Title = value;
                    break;
                case "storyline":
                    OldValue = movie.StoryLine;
                    movie.StoryLine = value;
                    break;
                case "airdate":
                    OldValue = movie.AirDate.ToString();
                    movie.AirDate = DateTime.Parse(value);
                    break;
                case "duration":
                    OldValue = movie.Duration.ToString();
                    movie.Duration = int.Parse(value);
                    break;
                case "avgrating":
                    var AvgRating = float.Parse(value);
                    if (AvgRating <= 10 && AvgRating >= 0)
                    {
                        OldValue = movie.AvgRating.ToString();
                        movie.AvgRating = AvgRating;
                    }
                    else
                    {
                        return BadRequest(new ResWrapper { Status = "InvalidValue", args = new { Id, field, value } });
                    }
                    break;
                case "votescount":
                    var VotesCount = long.Parse(value);
                    if (VotesCount >= 0)
                    {
                        OldValue = movie.VotesCount.ToString();
                        movie.VotesCount = VotesCount;
                    } else
                    {
                        return BadRequest(new ResWrapper { Status = "InvalidValue", args = new { Id, field, value } });
                    }
                    break;
                default:
                    return BadRequest(new ResWrapper { Status = "InvalidField", args = new { Id, field, value } });
            }
            db.SaveChanges();
            return Ok(new ResWrapper { Status = "OK", args = new { Id, field, value }, Data = new { OldValue, movie } });
        }
    }
}
