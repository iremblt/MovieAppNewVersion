using System.Collections.Generic;

namespace MovieAppNewVersion.Entities.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
