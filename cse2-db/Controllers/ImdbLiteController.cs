using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cse2_db.DataAccess;
using cse2_db.Entities;
using Microsoft.AspNetCore.Mvc;


namespace cse2_db.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ImdbLiteController : ControllerBase
    {
        private readonly MediaContext _db;
        public ImdbLiteController(MediaContext context)
        {
            _db = context;
        }
        //GET: /<controller>/
        //public IActionResult Index()
        //{
        //    List<Genre> genres = _db.Genres
        //        .Select(x => new Genre() { Id = x.Id, Name = x.Name })
        //        .ToList();
        //    return Ok(genres);
        //}

        // Request 1
        // GET: /genres
        public IActionResult Genres()
        {
            List<Genre> genres = _db.Genres
                .Select(x => new Genre() { Id = x.Id, Name = x.Name })
                .ToList();
            return Ok(genres);
        }

        // Request 2
        // GET: /ShowsByGenre?{id}
        public IActionResult ShowsByGenre(long Id)
        {
            Console.WriteLine(Id);
            /* in SQL SELECT "TvSeries"."Id", "TvSeries"."Title" FROM "TvSeries", "Season", "TvEpisode", "TvEpisodeGenre" 
		        Where 
			        "TvEpisodeGenre"."GenreId" = {Id} and 
			        "TvEpisodeGenre"."TvEpisodeId" = "TvEpisode"."Id" and 
			        "TvEpisode"."SeasonId" = "Season"."Id" and 
			        "Season"."TvSeriesId" = "TvSeries"."Id" Group By "TvSeries"."Id";
            */
            var result = (from TvSeries in _db.TvSeries
                          from Season in _db.Seasons
                          from TvEpisode in _db.TvEpisodes
                          from TvEpisodeGenre in _db.TvEpisodeGenres
                          where TvEpisodeGenre.GenreId == Id
                          where TvEpisode.Id == TvEpisodeGenre.TvEpisodeId
                          where Season.Id == TvEpisode.SeasonId
                          where TvSeries.Id == Season.TvSeriesId
                          select new { TvSeries.Id, TvSeries.Title, TvSeries.Image.ImageUrl, Type = "TvSeries" })
                         .Distinct()
                         .ToList()
                         .Concat((
                          from Movies in _db.Movies
                          from MovieGenre in _db.MovieGenres
                          where MovieGenre.GenreId == Id
                          where Movies.Id == MovieGenre.MovieId
                          select new { Movies.Id, Movies.Title, Movies.Image.ImageUrl, Type = "Movie" })
                         .Distinct());
            return Ok(result);
        }

        // Request 3
        // GET: /tvSeries?{id}
        public IActionResult TvSeries(long Id)
        {
            //TODO: Will be tuned!
            var result = (from TvSeries in _db.TvSeries
                          where TvSeries.Id == Id
                          select new
                          {
                              TvSeries.Id,
                              TvSeries.Title,
                              TvSeries.Image.ImageUrl,
                              TvSeries.ContentRating,
                              Genres = (from Season in _db.Seasons
                                        from TvEpisode in _db.TvEpisodes
                                        from TvEpisodeGenre in _db.TvEpisodeGenres
                                        from Genre in _db.Genres
                                        where Season.TvSeriesId == TvSeries.Id
                                        where TvEpisode.SeasonId == Season.Id
                                        where TvEpisode.Id == TvEpisodeGenre.TvEpisodeId
                                        where TvEpisodeGenre.GenreId == Genre.Id
                                        select Genre)
                                        .Distinct()
                                        .ToList() // Does not compare???
                          });
            return Ok(result);
        }

 
    }
}
