using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class Language
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        //public ICollection<MovieLanguage> MovieLangugages { get; set; }
        //public ICollection<TvEpisodeLanguage> TvEpisodeLanguages { get; set; }
    }
}
