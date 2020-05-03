using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cse2_db.DataAccess;
using cse2_db.DOTs;
using cse2_db.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cse2_db.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly MediaContext db;
        public PlatformController(MediaContext context)
        {
            db = context;
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Get()
        {
            var platforms = db.Platforms.Select(x => x);
            return Ok(new ResWrapper { Status = "OK", Data = platforms });
        }
        public IActionResult Add(string Name, string Url, string Description)
        {
            Platform platform = new Platform();
            platform.Name = Name;
            platform.Url = Url;
            platform.Description = Description;
            db.Platforms.Add(platform);
            db.SaveChanges();
            return Ok(new ResWrapper { Status = "OK", args = platform});
        }
        public IActionResult BindMovie(long MovieId, int PlatformId)
        {
            MoviePlatform moviePlatform = new MoviePlatform();
            moviePlatform.MovieId = MovieId;
            moviePlatform.PlatformId = PlatformId;
            db.MoviePlatforms.Add(moviePlatform);
            db.SaveChanges();
            return Ok(new ResWrapper { Status = "OK", args = moviePlatform });
        }
        public IActionResult BindTvSeries(long TvSeriesId, int PlatformId)
        {
            TvSeriesPlatform tvSeriesPlatform = new TvSeriesPlatform();
            tvSeriesPlatform.TvSeriesId = TvSeriesId;
            tvSeriesPlatform.PlatformId = PlatformId;
            db.TvSeriesPlatforms.Add(tvSeriesPlatform);
            db.SaveChanges();
            return Ok(new ResWrapper { Status = "OK", args = tvSeriesPlatform });
        }
        public IActionResult GetShowsByPlatform(long Id)
        {
            var result = (from TvSeriesPlatform in db.TvSeriesPlatforms
                          where TvSeriesPlatform.PlatformId == Id
                          select new { 
                              TvSeriesPlatform.TvSeries.Id,
                              TvSeriesPlatform.TvSeries.Title,
                              TvSeriesPlatform.TvSeries.Image.ImageUrl, 
                              Type = "TvSeries" 
                          })
                         .Distinct()
                         .ToList()
                         .Concat((
                          from MoviePlatform in db.MoviePlatforms
                          where MoviePlatform.PlatformId == Id
                          select new
                          {
                              MoviePlatform.Movie.Id,
                              MoviePlatform.Movie.Title,
                              MoviePlatform.Movie.Image.ImageUrl,
                              Type = "Movie" })
                         .Distinct());
            return Ok(result);
        }
    }
}
