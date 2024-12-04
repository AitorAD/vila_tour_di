using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di
{
    public class Recipe {

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imagensPaths { get; set; }
        public double averageScore { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModificationDate { get; set; }
        public string review { get; set; }
        public bool approved { get; set; }
        public bool recent { get; set; }
        public List<Ingredient> ingredients { get; set; }

        public Recipe(string name, string description, string imagesPaths, double averageScore, bool approved, bool recent, List<Ingredient> ingredients) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.imagensPaths = imagesPaths;
            this.averageScore = averageScore;
            this.review = review;
            this.approved = approved;
            this.recent = recent;
            this.ingredients = ingredients;
        }

        public Recipe() { 

        }
    }
}