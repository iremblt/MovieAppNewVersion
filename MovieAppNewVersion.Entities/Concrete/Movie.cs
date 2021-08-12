using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieAppNewVersion.Entities.Concrete
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDescription { get; set; }
        public string MovieImage { get; set; }
        public string MovieAbout { get; set; }
        public List<Category> Categories { get; set; }
        public List<Vote> Votes { get; set; }
    }
}
