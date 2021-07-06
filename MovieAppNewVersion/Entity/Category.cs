using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<Movie> Movies { get; set; } //Seed de new movie diyerk o türe ait film ekleyebilirim
    }
}
