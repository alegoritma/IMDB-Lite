using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cse2_db.DataAccess;
using cse2_db.DOTs;
using cse2_db.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cse2_db.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly MediaContext db;
        public PersonController(MediaContext context)
        {
            db = context;
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // Request: 7
        // GET: /person/id
        public async Task<IActionResult> Get(long Id)
        {
            /*{
                person: {
                    Id,
                    FullName,
                    BirthDate,
                    DeathDate,
                    ImageUrl,
                },
                credits: {
                    asActress: {
                        TvSeriesCount,
                        MoviesCount,
                        Movies: [  **OrderBy AirDate
                            {
                                Movie.Id,
                                Movie.Title,
                                Movie.AirDate, 
                                playedCharacters: [Name,...]
                            },...
                        ],
                        TvSeries: [
                            {
                                TvSeries.Id,
                                TvSeries.Title,
                                EpisodesCount,
                                FirstEpisodeDate,
                                LastEpisodeDate,
                                Episodes: [ **OrderBy AirDate
                                    {
                                        TvEpisode.Id,
                                        TvEpisode.Title,
                                        TvEpisode.AirDate,
                                        playedCharacters: [Name,...]
                                    },...
                                ]
                            }
                        ]
                    },
                    asDirector: {
                        TvSeriesCount,
                        MoviesCount,
                        Movies: [{ Movie.Id, Movie.Title, Movie.AirDate },... ],
                        TvSeries: [
                            {
                                TvSeries.Id,
                                TvSeries.Title,
                                EpisodesCount,
                                FirstEpisodeDate,
                                LastEpisodeDate,
                                Episodes: [ **OrderBy AirDate
                                    {
                                        TvEpisode.Id,
                                        TvEpisode.Title,
                                        TvEpisode.AirDate
                                    },...
                            }
                        ]
                    },
                    asWriter: [
                        {
                            TvSeriesCount,
                            MoviesCount,
                            Movies: [{ Movie.Id, Movie.Title, Movie.AirDate },... ],
                            TvSeries: [
                                {
                                    TvSeries.Id,
                                    TvSeries.Title,
                                    EpisodesCount,
                                    FirstEpisodeDate,
                                    LastEpisodeDate,
                                    Episodes: [ **OrderBy AirDate
                                        {
                                            TvEpisode.Id,
                                            TvEpisode.Title,
                                            TvEpisode.AirDate
                                        },...
                                }
                            ]
                        },...
                    ],
                    asProducer: [
                        {
                            TvSeriesCount,
                            MoviesCount,
                            Movies: [{ Movie.Id, Movie.Title, Movie.AirDate },... ],
                            TvSeries: [
                                {
                                    TvSeries.Id,
                                    TvSeries.Title,
                                    EpisodesCount,
                                    FirstEpisodeDate,
                                    LastEpisodeDate,
                                    Episodes: [ **OrderBy AirDate
                                        {
                                            TvEpisode.Id,
                                            TvEpisode.Title,
                                            TvEpisode.AirDate
                                        },...
                                }
                            ]
                        },...
                    ],
                    }
                }
                
             }*/

            // Complexity: 1
            var person = await  (from Person in db.People
                          where Person.Id == Id
                          select new
                          {
                              Person.Id,
                              Person.FullName,
                              Person.BirthDate,
                              Person.DeathDate,
                              Person.Image.ImageUrl                             
                          }).FirstOrDefaultAsync();
            
            if (person == null)
                return NotFound(new ResWrapper { Status = "NotFound", args = new { Id } });


            var asMovieDirector = await (from MovieDirector in db.MovieDirectors
                                         where MovieDirector.PersonId == Id
                                         select new
                                         {
                                             MovieDirector.Movie.Id,
                                             MovieDirector.Movie.Title,
                                             MovieDirector.Movie.AirDate
                                         }).ToListAsync();
            var asMovieWriter = await (from MovieWriter in db.MovieWriters
                                       where MovieWriter.PersonId == Id
                                       select new
                                       {
                                           MovieWriter.Movie.Id,
                                           MovieWriter.Movie.Title,
                                           MovieWriter.Movie.AirDate
                                       }).ToListAsync();
            var asMovieProducer = await (from MovieProducer in db.MovieProducers
                                         where MovieProducer.PersonId == Id
                                         select new
                                         {
                                             MovieProducer.Movie.Id,
                                             MovieProducer.Movie.Title,
                                             MovieProducer.Movie.AirDate
                                         }).ToListAsync();

            var asMovieActor = await (from MovieCast in db.MovieCasts
                                      where MovieCast.PersonId == Id
                                      select new
                                      {
                                          MovieCast.Movie.Id,
                                          MovieCast.Movie.Title,
                                          MovieCast.Movie.AirDate,
                                          playedCharacters = (from MovieCastCharacter in db.MovieCastCharacters
                                                              where MovieCast.Id == MovieCastCharacter.MovieCastId
                                                              select MovieCastCharacter.Character.Name).ToList()
                                      }).ToListAsync();

            // Complexity: ?
            var PersonTvSeries = new[]{
            /*asDirector*/ await (from TvEpisodeDirector in db.TvEpisodeDirectors
                                    where TvEpisodeDirector.PersonId == Id
                                    select TvEpisodeDirector.TvEpisode.Season.TvSeries).Distinct().ToListAsync(),
            /*asWriter*/   await (from TvEpisodeWriter in db.TvEpisodeWriters
                                    where TvEpisodeWriter.PersonId == Id
                                    select TvEpisodeWriter.TvEpisode.Season.TvSeries).Distinct().ToListAsync(),
            /*asProducer*/ await (from TvEpisodeProducer in db.TvEpisodeProducers
                                    where TvEpisodeProducer.PersonId == Id
                                    select TvEpisodeProducer.TvEpisode.Season.TvSeries).Distinct().ToListAsync(),
            /*asActor*/    await (from TvEpisodeCast in db.TvEpisodeCasts
                                    where TvEpisodeCast.PersonId == Id
                                    select TvEpisodeCast.TvEpisode.Season.TvSeries).Distinct().ToListAsync()
            };

            var asTvSeriesDirector = (from TvSeries in PersonTvSeries[0]
                                      select new
                                      {
                                          TvSeries.Id,
                                          TvSeries.Title,
                                          EpisodesCount = db.TvEpisodes.Where(x => x.Season.TvSeriesId == TvSeries.Id).Count(),
                                          Episodes = (from TvEpisode in db.TvEpisodes
                                                      where TvEpisode.Season.TvSeriesId == TvSeries.Id
                                                      select new
                                                      {
                                                          TvEpisode.Id,
                                                          TvEpisode.Title,
                                                          TvEpisode.AirDate,
                                                      }).ToList(),
                                      });
            var asTvSeriesWriter = (from TvSeries in PersonTvSeries[1]
                                    select new
                                    {
                                        TvSeries.Id,
                                        TvSeries.Title,
                                        EpisodesCount = db.TvEpisodes.Where(x => x.Season.TvSeriesId == TvSeries.Id).Count(),
                                        Episodes = (from TvEpisode in db.TvEpisodes
                                                    where TvEpisode.Season.TvSeriesId == TvSeries.Id
                                                    select new
                                                    {
                                                        TvEpisode.Id,
                                                        TvEpisode.Title,
                                                        TvEpisode.AirDate,
                                                    }).ToList(),
                                    });
            var asTvSeriesProducer = (from TvSeries in PersonTvSeries[2]
                                      select new
                                      {
                                          TvSeries.Id,
                                          TvSeries.Title,
                                          EpisodesCount = db.TvEpisodes.Where(x => x.Season.TvSeriesId == TvSeries.Id).Count(),
                                          Episodes = (from TvEpisode in db.TvEpisodes
                                                      where TvEpisode.Season.TvSeriesId == TvSeries.Id
                                                      select new
                                                      {
                                                          TvEpisode.Id,
                                                          TvEpisode.Title,
                                                          TvEpisode.AirDate,
                                                      }).ToList(),
                                      });

            var asTvSeriesActor = (from TvSeries in PersonTvSeries[3]
                                   select new
                                   {
                                       TvSeries.Id,
                                       TvSeries.Title,
                                       EpisodesCount = db.TvEpisodes.Where(x => x.Season.TvSeriesId == TvSeries.Id).Count(),
                                       Episodes = (from TvEpisodeCast in db.TvEpisodeCasts
                                                   where TvEpisodeCast.TvEpisode.Season.TvSeriesId == TvSeries.Id
                                                   select new
                                                   {
                                                       TvEpisodeCast.TvEpisode.Id,
                                                       TvEpisodeCast.TvEpisode.Title,
                                                       TvEpisodeCast.TvEpisode.AirDate,
                                                       playedCharacters = (from TvEpisodeCastCharacter in db.TvEpisodeCastCharacters
                                                                           where TvEpisodeCast.Id == TvEpisodeCastCharacter.TvEpisodeCastId
                                                                           select TvEpisodeCastCharacter.Character.Name).ToList()
                                                   }).ToList(),
                                   });

            var data = new
            {
                person,
                credits = new
                {
                    asDirector = new
                    {
                        TvSeriesTotal = PersonTvSeries[0].Count,
                        MoviesTotal = asMovieDirector.Count,
                        TvSeries = asTvSeriesDirector,
                        Movies = asMovieDirector,
                    },
                    asWriter = new
                    {
                        TvSeriesTotal = PersonTvSeries[1].Count,
                        MoviesTotal = asMovieWriter.Count,
                        TvSeries = asTvSeriesWriter,
                        Movies = asMovieWriter,
                    },
                    asProducer = new
                    {
                        TvSeriesTotal = PersonTvSeries[2].Count,
                        MoviesTotal = asMovieProducer.Count,
                        TvSeries = asTvSeriesProducer,
                        Movies = asMovieProducer
                    },
                    asActor = new
                    {
                        TvSeriesTotal = PersonTvSeries[3].Count,
                        MoviesTotal = asMovieActor.Count,
                        TvSeries = asTvSeriesActor,
                        Movies = asMovieActor
                    },
                }
            };

            return Ok(new ResWrapper { Status = "Ok", args = new { Id }, Data = data });
        }

        // Request 10
        public IActionResult Update(long Id, string field, string value)
        {
            var query = (from Person in db.People
                         where Person.Id == Id
                         select Person);
            if (!query.Any())
                return NotFound(new ResWrapper { Status = "NotFound", args = new { Id, field, value } });

            var person = query.Single();
            
            string OldValue = "";
            //Fields fullname birthdate deathdate
            switch (field.ToLower())
            {
                case "fullname":
                    OldValue = person.FullName;
                    person.FullName = value;
                    break;
                case "birthdate":
                    OldValue = person.BirthDate.ToString();
                    person.BirthDate = DateTime.Parse(value);
                    break;
                case "deathdate":
                    OldValue = person.DeathDate.ToString();
                    person.DeathDate = DateTime.Parse(value);
                    break;
                default:
                    return BadRequest(new ResWrapper { Status = "InvalidField", args = new { Id, field, value } });
            }

            db.SaveChanges();

            return Ok(new ResWrapper { Status = "OK", args = new { Id, field, value }, Data = new { OldValue, person } });
        }
    }
}
