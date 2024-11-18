using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di {
    internal class Recipe {

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imagesPaths { get; set; }
        public double averageScore { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModificationDate { get; set; }
        public string review { get; set; }
        public bool approved { get; set; }
        public bool recent { get; set; }
        public List<Ingredient> ingredients { get; set; }

    }
}