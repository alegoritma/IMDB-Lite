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
    public class SeasonController : ControllerBase
    {
        private readonly MediaContext db;
        public SeasonController(MediaContext context)
        {
            db = context;
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    Ok();
        //}
        // Request 5
        public IActionResult Get(long Id)
        {
            /*{
                SeasonNumber,
                episodes [
                    {
                        TvEpisode.Id,
                        TvEpisode.Title,
                        TvEpisode.Duration,
                        TvEpisode.AvgRating,
                        TvEpisode.Image.ImageUrl
                    },...
                ]
             }*/

            // Complexity: 1
            var episodes = (from TvEpisode in db.TvEpisodes
                            where TvEpisode.SeasonId == Id
                            orderby TvEpisode.EpisodeNumber
                            select new
                            {
                                TvEpisode.Id,
                                TvEpisode.Title,
                                TvEpisode.Duration,
                                TvEpisode.AvgRating,
                                TvEpisode.Image.ImageUrl
                            }).ToList();
            // Complexity: 1
            var season = (from Season in db.Seasons
                          where Season.Id == Id
                          select new
                          {
                              Season.SeasonNumber,
                              episodes
                          });

            if (!season.Any())
                return NotFound(new ResWrapper { Status = "NotFound", args = new { Id } });

            return Ok(new ResWrapper { Status = "OK", args = new { Id }, Data = season.Single() });
        }
    }
}
