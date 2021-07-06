using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Entity
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDescription { get; set; }
        public string MovieImage { get; set; }
        public string MovieAbout { get; set; }

        public List<Category> Categories { get; set; }
    }
}
