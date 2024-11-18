using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vila_tour_di {
    class Ingredient {
        public int id { get; set; }
        public string name { get; set; }
        public CategoryIngredient categoryIngredient { get; set; }

        public Ingredient(int id, string name, CategoryIngredient categoryIngredient) {
            this.id = id;
            this.name = name;
            this.categoryIngredient = categoryIngredient;
        }

        public Ingredient() {
            
        }

        public override string ToString() {
            return $"Name: {name}, Category: {categoryIngredient}";
        }
    }
}