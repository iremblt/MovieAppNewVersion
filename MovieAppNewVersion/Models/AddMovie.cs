using MovieAppNewVersion.Data;
using MovieAppNewVersion.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Models
{
    public class AddMovie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieImage { get; set; }
        public string MovieAbout { get; set; }
        public string MovieDescription { get; set; }
        public List<Category> Categories { get; set; }

    }
}
