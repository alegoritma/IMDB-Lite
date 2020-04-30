using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cse2_db.DataAccess;
using cse2_db.DOTs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cse2_db.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TvEpisodeController : ControllerBase
    {
        private readonly MediaContext db;
        public TvEpisodeController(MediaContext context)
        {
            db = context;
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Get(long Id)
        {
            // Complexities: 9
            var companies = (from Company in db.Companies
                             from TvEpisodeCompany in db.TvEpisodeCompanies
                             where TvEpisodeCompany.TvEpisodeId == Id
                             where Company.Id == TvEpisodeCompany.CompanyId
                             select Company).ToList();

            var languages = (from Language in db.Languages
                             from TvEpisodeLanguage in db.TvEpisodeLanguages
                             where TvEpisodeLanguage.TvEpisodeId == Id
                             where Language.Id == TvEpisodeLanguage.LanguageId
                             select Language).ToList();

            var locations = (from Location in db.Locations
                             from TvEpisodeLocation in db.TvEpisodeLocations
                             where TvEpisodeLocation.TvEpisodeId == Id
                             where Location.Id == TvEpisodeLocation.LocationId
                             select Location).ToList();

            var genres = (from TvEpisodeGenre in db.TvEpisodeGenres
                          from Genre in db.Genres
                          where TvEpisodeGenre.TvEpisodeId == Id
                          where Genre.Id == TvEpisodeGenre.GenreId
                          select Genre).ToList();

            var countries = (from TvEpisodeCountry in db.TvEpisodeCountries
                             from Country in db.Countries
                             where TvEpisodeCountry.TvEpisodeId == Id
                             where Country.Id == TvEpisodeCountry.CountryId
                             select Country).ToList();

            var keywords = (from KeyWord in db.KeyWords
                            from TvEpisodeKeyWord in db.TvEpisodeKeyWords
                            where TvEpisodeKeyWord.TvEpisodeId == Id
                            where KeyWord.Id == TvEpisodeKeyWord.KeyWordId
                            select KeyWord).ToList();

            var directors = (from TvEpisodeDirector in db.TvEpisodeDirectors
                             from Person in db.People
                             where TvEpisodeDirector.TvEpisodeId == Id
                             where TvEpisodeDirector.PersonId == Person.Id
                             select new
                             {
                                 PersonId = Person.Id,
                                 Person.FullName,
                                 Person.Image.ImageUrl,
                                 Person.BirthDate,
                                 Person.DeathDate
                             }).ToList();

            var writers = (from TvEpisodeWriter in db.TvEpisodeWriters
                           from Person in db.People
                           where TvEpisodeWriter.TvEpisodeId == Id
                           where TvEpisodeWriter.PersonId == Person.Id
                           select new
                           {
                               PersonId = Person.Id,
                               Person.FullName,
                               Person.Image.ImageUrl,
                               Person.BirthDate,
                               Person.DeathDate
                           }).ToList();

            var producers = (from TvEpisodeProducer in db.TvEpisodeProducers
                             from Person in db.People
                             where TvEpisodeProducer.TvEpisodeId == Id
                             where TvEpisodeProducer.PersonId == Person.Id
                             select new
                             {
                                 PersonId = Person.Id,
                                 Person.FullName,
                                 Person.Image.ImageUrl,
                                 Person.BirthDate,
                                 Person.DeathDate
                             }).ToList();

            // Complexity: n+1
            var cast = (from TvEpisodeCast in db.TvEpisodeCasts
                        from Person in db.People
                        where TvEpisodeCast.TvEpisodeId == Id
                        where TvEpisodeCast.PersonId == Person.Id
                        orderby TvEpisodeCast.Importance
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
                                          from TvEpisodeCastCharacter in db.TvEpisodeCastCharacters
                                          where TvEpisodeCastCharacter.TvEpisodeCastId == TvEpisodeCast.Id
                                          where Character.Id == TvEpisodeCastCharacter.CharacterId
                                          select Character).ToList()
                        }).ToList();

            // Complexity: 1
            var tvEpisode = (from TvEpisode in db.TvEpisodes
                             where TvEpisode.Id == Id
                             select new
                             {
                                 TvEpisode.Id,
                                 TvEpisode.Title,
                                 TvEpisode.StoryLine,
                                 TvEpisode.AirDate,
                                 TvEpisode.Image.ImageUrl,
                                 TvEpisode.Duration,
                                 TvEpisode.AvgRating,
                                 TvEpisode.VotesCount,
                                 companies,
                                 languages,
                                 locations,
                                 genres,
                                 countries,
                                 keywords,
                                 Crew = new
                                 {
                                     directors,
                                     writers,
                                     producers,
                                     cast
                                 }
                             });

            if (!tvEpisode.Any())
                return NotFound(new ResWrapper { Status = "NotFound", args = new { Id } });

            return Ok(new ResWrapper { Status = "OK", args = new { Id }, Data = tvEpisode.Single() });
        }
    }
}
