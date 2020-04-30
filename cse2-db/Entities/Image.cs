using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cse2_db.Entities
{
    public class Image
    {
        public long Id { get; set; }
        //public long MovieId { get; set; }
        [MaxLength(5000)]
        public string ImageUrl { get; set; }
    }
}
