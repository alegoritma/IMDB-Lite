using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class Company
    {
        public long Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        //public ICollection<MovieCompany> MovieCompanies { get; set; }
        //public ICollection<TvEpisodeCompany> TvEpisodeCompanies { get; set; }
    }
}
