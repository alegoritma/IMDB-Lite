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
    public class TvSeriesController : ControllerBase
    {
        private readonly MediaContext db;
        public TvSeriesController(MediaContext context)
        {
            db = context;
        }
        // Response 3
        // GET: /tvseries
        //public IActionResult Index()
        //{
        //    var result = _db.TvSer;
        //    return Ok();
        //}
        public async Task<IActionResult> Get(long Id)
        {
            /*{
                TvSeries.Id,
                TvSeries.Title,
                TvSeries.StoryLine,
                TvSeries.PublishDate,
                TvSeries.Image.ImageUrl,
                TvSeries.Duration,
                TvSeries.ContentRating.Name,
                TvSeries.AvgRating,
                TvSeries.VotesCount,
                TvSeries.TvEpisode.Count(),
                Crew : {
                    Cast: {
                    
                }    
                }
                Platforms: [ { Platform.Name },... ],
                Seasons: [  **OrderBy SeasonNumber
                          {
                            Season.Id,
                            Season.SeasonNumber,
                          },...
                ]

            }*/

            // Complexity: ?
            var tvEpisodeIds = await (from TvEpisode in db.TvEpisodes
                                      where TvEpisode.Season.TvSeriesId == Id
                                      select TvEpisode.Id).ToListAsync();

            var castPeople = (from TvEpisodeCast in db.TvEpisodeCasts
                              where TvEpisodeCast.TvEpisode.Season.TvSeriesId == Id
                              select new
                              {
                                  PersonId = TvEpisodeCast.Person.Id,
                                  TvEpisodeCast.Person.FullName,
                                  TvEpisodeCast.Person.Image.ImageUrl,
                                  TvEpisodeCast.Person.BirthDate,
                                  TvEpisodeCast.Person.DeathDate
                              })
                            .Distinct();

            var castCharacters = (from TvEpisodeCastCharacter in db.TvEpisodeCastCharacters
                                  where TvEpisodeCastCharacter.TvEpisodeCast.TvEpisode.Season.TvSeriesId == Id
                                  select new
                                  {
                                      TvEpisodeCastCharacter.TvEpisodeCast.PersonId,
                                      TvEpisodeCastCharacter.Character
                                  }).Distinct();

            var cast = (from Person in castPeople
                        let TvEpisodes = (from TvEpisodeCastCharacter in db.TvEpisodeCastCharacters
                                          where TvEpisodeCastCharacter.TvEpisodeCast.PersonId == Person.PersonId
                                          let TvEpisode = TvEpisodeCastCharacter.TvEpisodeCast.TvEpisode
                                          select new
                                          {
                                              TvEpisode.Id,
                                              //TvEpisode.Title,
                                              TvEpisode.AirDate
                                          }).Distinct()
                        select new
                        {
                            Person,
                            //TvEpisodes,
                            characters = (from TvEpisodeCastCharacter in castCharacters
                                          where TvEpisodeCastCharacter.PersonId == Person.PersonId
                                          select TvEpisodeCastCharacter.Character).Distinct().ToList(),
                            episodesCount = TvEpisodes.Count(),
                            firstAppearence = TvEpisodes.Min(x => x.AirDate),
                            lastAppearence = TvEpisodes.Max(x => x.AirDate)
                        }).ToList();


            var directors = (await (from TvEpisodeDirector in db.TvEpisodeDirectors
                                    where TvEpisodeDirector.TvEpisode.Season.TvSeriesId == Id
                                    select new
                                    {
                                        Person = new
                                        {
                                            PersonId = TvEpisodeDirector.Person.Id,
                                            TvEpisodeDirector.Person.FullName,
                                            TvEpisodeDirector.Person.Image.ImageUrl
                                        },
                                        TvEpisodeDirector.TvEpisode.AirDate
                                    }).ToListAsync())
                                    .GroupBy(
                                        d => d.Person,
                                        d => d.AirDate,
                                        (person, airdates) => new
                                        {
                                            person,
                                            episodesCount = airdates.Count(),
                                            firstAppearence = airdates.Max(),
                                            lastAppearence = airdates.Min()
                                        });
            var writers =  (await (from TvEpisodeWriter in db.TvEpisodeWriters
                                    where TvEpisodeWriter.TvEpisode.Season.TvSeriesId == Id
                                    select new
                                    {
                                        Person = new
                                        {
                                            PersonId = TvEpisodeWriter.Person.Id,
                                            TvEpisodeWriter.Person.FullName,
                                            TvEpisodeWriter.Person.Image.ImageUrl
                                        },
                                        TvEpisodeWriter.TvEpisode.AirDate
                                    }).ToListAsync())
                                    .GroupBy(
                                        d => d.Person,
                                        d => d.AirDate,
                                        (person, airdates) => new
                                        {
                                            person,
                                            episodesCount = airdates.Count(),
                                            firstAppearence = airdates.Max(),
                                            lastAppearence = airdates.Min()
                                        });
            var producers=(await (from TvEpisodeProducer in db.TvEpisodeProducers
                                  where TvEpisodeProducer.TvEpisode.Season.TvSeriesId == Id
                                  select new
                                  {
                                      Person = new
                                      {
                                          PersonId = TvEpisodeProducer.Person.Id,
                                          TvEpisodeProducer.Person.FullName,
                                          TvEpisodeProducer.Person.Image.ImageUrl
                                      },
                                      TvEpisodeProducer.TvEpisode.AirDate
                                  }).ToListAsync())
                                    .GroupBy(
                                        d => d.Person,
                                        d => d.AirDate,
                                        (person, airdates) => new
                                        {
                                            person,
                                            episodesCount = airdates.Count(),
                                            firstAppearence = airdates.Max(),
                                            lastAppearence = airdates.Min()
                                        });
            //var cast = await   (from TvEpisodeCast in db.TvEpisodeCasts
            //                    where TvEpisodeCast.TvEpisode.Season.TvSeriesId == Id
            //                    orderby TvEpisodeCast.Importance
            //                    group TvEpisodeCast by TvEpisodeCast.Person into PersonGroup
            //                    select new
            //                    {
            //                        person = new
            //                        {
            //                            PersonGroup.Key.Id,
            //                            PersonGroup.Key.FullName,
            //                            PersonGroup.Key.BirthDate,
            //                            PersonGroup.Key.DeathDate,
            //                            PersonGroup.Key.Image.ImageUrl
            //                        },
            //                        characters = (from TvEpisodeCast in PersonGroup
            //                                      from TvEpisodeCastCharacter in db.TvEpisodeCastCharacters
            //                                      where TvEpisodeCast.PersonId == PersonGroup.Key.Id
            //                                      where TvEpisodeCastCharacter.TvEpisodeCastId == TvEpisodeCast.Id
            //                                      select TvEpisodeCastCharacter.Character.Name).ToList()
            //                    }).ToListAsync();

            // Complexity: 1
            var seasons = (from Season in db.Seasons
                           where Season.TvSeriesId == Id
                           orderby Season.SeasonNumber
                           select new { Season.Id, Season.SeasonNumber });

            // Complexity: n
            var episodesCount = (from TvEpisode in db.TvEpisodes
                                 from season in seasons
                                 where TvEpisode.SeasonId == season.Id
                                 select true).Count();
            // Complexity: n?
            var platforms = (from TvSeriesPlatform in db.TvSeriesPlatforms
                             from Platform in db.Platforms
                             where TvSeriesPlatform.TvSeriesId == Id
                             where TvSeriesPlatform.PlatformId == Platform.Id
                             select Platform).ToList();
            // Complexity: 1
            var tvSeries = (from TvSeries in db.TvSeries
                            where TvSeries.Id == Id
                            select new
                            {
                                TvSeries.Id,
                                TvSeries.Title,
                                TvSeries.StoryLine,
                                TvSeries.PublishDate,
                                TvSeries.Image.ImageUrl,
                                TvSeries.Duration,
                                ContentRating = TvSeries.ContentRating.Name,
                                episodesCount,
                                TvSeries.AvgRating,
                                TvSeries.VotesCount,
                                Platforms = platforms,
                                Seasons = seasons.ToList(),
                                Crew = new
                                {
                                    directors,
                                    writers,
                                    producers,
                                    cast
                                }
                            });

           

            if (!tvSeries.Any())
                return NotFound(new ResWrapper { Status = "NotFound", args = new { Id } });

            return Ok(new ResWrapper { Status = "OK", Data = tvSeries.Single(), args = new { Id } });
        }

        // Request 9
        public IActionResult Update(long Id, string field, string value)
        {
            var query = (from TvSeries in db.TvSeries
                         where TvSeries.Id == Id
                         select TvSeries);
            if (!query.Any())
                return NotFound(new ResWrapper { Status = "NotFound", args = new { Id, field, value } });

            var tvSeries = query.Single();
            string OldValue = "";
            //Fields Title, StoryLine, AirDate, Duration, AvgRating, VoteCount
            switch (field.ToLower())
            {
                case "title":
                    OldValue = tvSeries.Title;
                    tvSeries.Title = value;
                    break;
                case "storyline":
                    OldValue = tvSeries.StoryLine;
                    tvSeries.StoryLine = value;
                    break;
                case "duration":
                    OldValue = tvSeries.Duration.ToString();
                    tvSeries.Duration = int.Parse(value);
                    break;
                case "avgrating":
                    var AvgRating = float.Parse(value);
                    if (AvgRating <= 10 && AvgRating >= 0)
                    {
                        OldValue = tvSeries.AvgRating.ToString();
                        tvSeries.AvgRating = AvgRating;
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
                        OldValue = tvSeries.VotesCount.ToString();
                        tvSeries.VotesCount = VotesCount;
                    }
                    else
                    {
                        return BadRequest(new ResWrapper { Status = "InvalidValue", args = new { Id, field, value } });
                    }
                    break;
                default:
                    return BadRequest(new ResWrapper { Status = "InvalidValue", args = new { Id, field, value } });
            }
            db.SaveChanges();
            return Ok(new ResWrapper { Status = "OK", args = new { Id, field, value }, Data = new { OldValue, tvSeries } });
        }
        public async Task<IActionResult> RemovePerson(long TvSeriesId, long PersonId)
        {
            // Relations to Remove Records:
            // TvEpisodeCast and TvEpisodeCastCharacter (PersonId) 
            // TvEpisodeDirector (PersonId)
            // TvEpisodeWriter (PersonId)
            // TvEpisodeProducer
            var tvEpisodeCast = await (from TvEpisodeCast in db.TvEpisodeCasts
                                       where TvEpisodeCast.PersonId == PersonId
                                       where TvEpisodeCast.TvEpisode.Season.TvSeriesId == TvSeriesId
                                       select TvEpisodeCast).ToListAsync();
            var tvEpisodeCastCharacter = await (from TvEpisodeCastCharacter in db.TvEpisodeCastCharacters
                                                from TvEpisodeCast in db.TvEpisodeCasts
                                                where TvEpisodeCastCharacter.TvEpisodeCastId == TvEpisodeCast.Id
                                                where TvEpisodeCast.TvEpisode.Season.TvSeriesId == TvSeriesId
                                                where TvEpisodeCast.PersonId == PersonId
                                                select TvEpisodeCastCharacter).ToListAsync();
            var tvEpisodeDirector = await (from TvEpisodeDirector in db.TvEpisodeDirectors
                                           where TvEpisodeDirector.PersonId == PersonId
                                           where TvEpisodeDirector.TvEpisode.Season.TvSeriesId == TvSeriesId
                                           select TvEpisodeDirector).ToListAsync();
            var tvEpisodeWriter = await (from TvEpisodeWriter in db.TvEpisodeWriters
                                         where TvEpisodeWriter.PersonId == PersonId
                                         where TvEpisodeWriter.TvEpisode.Season.TvSeriesId == TvSeriesId
                                         select TvEpisodeWriter).ToListAsync();
            var tvEpisodeProducer = await (from TvEpisodeProducer in db.TvEpisodeProducers
                                           where TvEpisodeProducer.PersonId == PersonId
                                           where TvEpisodeProducer.TvEpisode.Season.TvSeriesId == TvSeriesId
                                           select TvEpisodeProducer).ToListAsync();

            db.TvEpisodeCasts.RemoveRange(tvEpisodeCast);
            db.TvEpisodeCastCharacters.RemoveRange(tvEpisodeCastCharacter);
            db.TvEpisodeDirectors.RemoveRange(tvEpisodeDirector);
            db.TvEpisodeWriters.RemoveRange(tvEpisodeWriter);
            db.TvEpisodeProducers.RemoveRange(tvEpisodeProducer);

            return Ok(new {
                tvEpisodeCast,
                tvEpisodeDirector,
                tvEpisodeWriter,
                tvEpisodeProducer
            });
            //var P = db.TvEpisodeCasts
            //                        .Where(x => x.PersonId == PersonId)
            //                        .Where(x => x.TvEpisode.Season.TvSeriesId == TvSeriesId).Select(x => x);

        }
    }
}
