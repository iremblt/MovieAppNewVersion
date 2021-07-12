using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Models
{
    public class AddCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<MovieViewMode> MovieModels { get; set; }
    }
}
